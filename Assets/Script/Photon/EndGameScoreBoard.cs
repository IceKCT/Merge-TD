using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class EndGameScoreBoard : MonoBehaviourPunCallbacks
{
    public Text playerNameText;
    public Text playerHealthText;
    public Text playerScoreText;

    Player player;
    public void Initialize(Player player)
    {
        this.player = player;
        playerNameText.text = player.NickName;
        UpdateFinalStatus();
    }
    public void UpdateFinalStatus()
    {
        if (player.CustomProperties.TryGetValue(("health"), out object health))
        {
            playerHealthText.text = health.ToString();
        }
        if (player.CustomProperties.TryGetValue(("score"), out object score))
        {
            playerScoreText.text = score.ToString();
        }
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer == player)
        {
            if (changedProps.ContainsKey("health") || changedProps.ContainsKey("score"))
            {
                UpdateFinalStatus();
            }
        }
    }
}
