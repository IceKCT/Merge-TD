using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Timer : MonoBehaviourPunCallbacks
{
    [SerializeField] Text timerText;
    [SerializeField] GameObject preparingWindow;

    int timerIncrementValue;
    int startTime = 30;
    [SerializeField] int timer = 30;
    bool startTimer = false;
    public bool timerisover;
    public static Timer instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if (!startTimer)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Hashtable time = new Hashtable();
                startTime = (int)PhotonNetwork.Time;
                startTimer = true;
                time.Add("StartTime", startTime);
                PhotonNetwork.CurrentRoom.SetCustomProperties(time);
            }
            else
            {
                startTime = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
                startTimer = true;
            }
        }
        else
        {
            if (timerisover == false)
            {
                timerIncrementValue = ((int)PhotonNetwork.Time - startTime);
                timerText.text = (timer - timerIncrementValue).ToString();
            }
            if (timerIncrementValue >= timer)
            {
                timerisover = true;
                preparingWindow.SetActive(false);
            }
        }       
    }
}
