using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class EndGame : MonoBehaviourPunCallbacks
{
    [Header("PREFAB")]
    [SerializeField] GameObject playerLastInfoPrefab;
    [Header("TRANSFORM")]
    [SerializeField] Transform finalScoreTable;

    Dictionary<Player, EndGameScoreBoard> finalScoreBoard = new Dictionary<Player, EndGameScoreBoard>();

    void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddFinalScoreBoardItem(player);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddFinalScoreBoardItem(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreBoardItem(otherPlayer);
    }
    public void AddFinalScoreBoardItem(Player player)
    {
        EndGameScoreBoard item = Instantiate(playerLastInfoPrefab, finalScoreTable).GetComponent<EndGameScoreBoard>();
        item.Initialize(player);
        finalScoreBoard[player] = item;
    }

    void RemoveScoreBoardItem(Player player)
    {
        Destroy(finalScoreBoard[player].gameObject);
        finalScoreBoard.Remove(player);
    }
}
