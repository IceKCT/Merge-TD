using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class SelectHeroPanel : MonoBehaviourPunCallbacks
{
    private Dictionary<int, GameObject> playerListEntries;
    public GameObject playerIngamePrefab;
    void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GameObject p = Instantiate(playerIngamePrefab);
            p.GetComponent<PlayerReadyCheck>().Initialize(player.ActorNumber, player.NickName);
            object isplayerReady;
            if (player.CustomProperties.TryGetValue(PlayerReadyCheck.PLAYER_READY , out isplayerReady))
            {
                p.GetComponent<PlayerReadyCheck>().SetPlayerReady((bool)isplayerReady);
            }
            playerListEntries.Add(player.ActorNumber, p);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Destroy(playerListEntries[otherPlayer.ActorNumber].gameObject);
        playerListEntries.Remove(otherPlayer.ActorNumber);
    }
    public override void OnLeftRoom()
    {
        foreach (GameObject entry in playerListEntries.Values)
        {
            Destroy(entry.gameObject);
        }

        playerListEntries.Clear();
        playerListEntries = null;
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (playerListEntries == null)
        {
            playerListEntries = new Dictionary<int, GameObject>();
        }

        GameObject entry;
        if (playerListEntries.TryGetValue(targetPlayer.ActorNumber, out entry))
        {
            object isPlayerReady;
            if (changedProps.TryGetValue(PlayerReadyCheck.PLAYER_READY, out isPlayerReady))
            {
                entry.GetComponent<PlayerReadyCheck>().SetPlayerReady((bool)isPlayerReady);
            }
            StartGame(CheckPlayerReady());
        }
    }
    private bool CheckPlayerReady()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return false;
        }

        foreach (Player p in PhotonNetwork.PlayerList)
        {
            object isPlayerReady;
            if (p.CustomProperties.TryGetValue(PlayerReadyCheck.PLAYER_READY, out isPlayerReady))
            {
                if (!(bool)isPlayerReady)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
    public void StartGame(bool ready)
    {
        if (ready)
        {
            Time.timeScale = 1;
        }
    }
}
