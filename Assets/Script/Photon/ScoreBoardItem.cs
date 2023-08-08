using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ScoreBoardItem : MonoBehaviourPunCallbacks
{
    public Text userNameText;
    public Text healthText;
    public Text moneyText;
    public Text scoreText;

    Player player;
    public void Initialize(Player player)
    {
        this.player = player;
        userNameText.text = player.NickName;
        UpdateStatus();
    }
    public void UpdateStatus()
    {
        if (player.CustomProperties.TryGetValue(("money"),out object money))
        {
            moneyText.text = money.ToString();
            //Debug.Log("Update Money");
        }
        if (player.CustomProperties.TryGetValue(("health"), out object health))
        {
            healthText.text = health.ToString();
            //Debug.Log("Update health");
        }
        if (player.CustomProperties.TryGetValue(("score"), out object score))
        {
            scoreText.text = score.ToString();
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if (targetPlayer == player)
        {
            if (changedProps.ContainsKey("money") || changedProps.ContainsKey("health") || changedProps.ContainsKey("score"))
            {
                //Debug.Log("targetplayer == player");
                UpdateStatus();
            }
        }
    }


}