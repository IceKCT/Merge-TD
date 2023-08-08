using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;

public class TestSendScore : MonoBehaviour
{
    public PlayfabManager playfabManager;
    public void TestSend()
    {
        playfabManager.SendLeaderBoard(Random.Range(0,100));
    }
}
