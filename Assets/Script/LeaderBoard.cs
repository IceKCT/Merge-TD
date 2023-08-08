using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class LeaderBoard : MonoBehaviour
{
    [Header("WINDOW")]
    [SerializeField] GameObject leaderBoardWIndow;
    [SerializeField] GameObject mainMenuWindow;
    [SerializeField] GameObject towerElemntNameWindow;
    public void BackButton()
    {
        leaderBoardWIndow.SetActive(false);
        mainMenuWindow.SetActive(true);
        towerElemntNameWindow.SetActive(true);
    }
    public void LeaderBoardButton()
    {
        leaderBoardWIndow.SetActive(true);
        mainMenuWindow.SetActive(false);
        towerElemntNameWindow.SetActive(false);
    }
}
