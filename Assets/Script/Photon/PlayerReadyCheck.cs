using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;
public class PlayerReadyCheck : MonoBehaviour
{
    public Text playerNameText;
    public Button playerReadyButton;
    public Image playerReadyStatus;

    private int ownerId;
    private bool isPlayerReady;
    public const string PLAYER_READY = "IsPlayerReady";

    private void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber != ownerId)
        {
            playerReadyButton.gameObject.SetActive(false);
        }
        else
        {
            Hashtable hash = new Hashtable() { { PLAYER_READY, isPlayerReady } };
            PhotonNetwork.SetPlayerCustomProperties(hash);

            playerReadyButton.onClick.AddListener(() =>
                {
                isPlayerReady = !isPlayerReady;
                SetPlayerReady(isPlayerReady);

                Hashtable props = new Hashtable() { { PLAYER_READY, isPlayerReady } };
                PhotonNetwork.LocalPlayer.SetCustomProperties(props);
            });
        }
    }
    public void SetPlayerReady(bool playerReady)
    {
        playerReadyButton.GetComponentInChildren<Text>().text = playerReady ? "Ready!" : "Ready?";
        playerReadyStatus.enabled = playerReady;
    }
    public void Initialize(int playerId, string playerName)
    {
        ownerId = playerId;
        playerNameText.text = playerName;
    }
}
