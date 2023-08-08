using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class OptionSettingButton : MonoBehaviourPunCallbacks
{
    public GameObject optionMenu;
    public GameObject settingButton;
    public GameObject SettingPanel;
    public static bool isGamePause = false;
    public static bool isGameSetting = false;

    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (isGamePause)
                {
                    ResumeGame();
                }
                else
                {
                    OpenOption();
                }
                if (isGameSetting)
                {
                    ResumeGameTwo();
                }
            }
        
       
    }
    public void OpenOption()
    {
        optionMenu.SetActive(true);
        settingButton.SetActive(false);
        isGamePause = true;

    }
    public void OpenSetting()
    {
        optionMenu.SetActive(false);
        SettingPanel.SetActive(true);
        isGameSetting = true;
    }

    public void BackSetting()
    {
        optionMenu.SetActive(true);
        SettingPanel.SetActive(false);
        isGameSetting = false;
    }
    public void QuitGame()
    {
        Debug.Log("Game is quit");
        Application.Quit();
    }
    public void ResumeGame()
    {
        optionMenu.SetActive(false);
        settingButton.SetActive(true);
        isGamePause = false;
    }
    public void ResumeGameTwo()
    {
        optionMenu.SetActive(false);
        settingButton.SetActive(true);
        SettingPanel.SetActive(false);
        isGamePause = false;
        isGameSetting = false;
    }

    public void MainMenuButton()
    {
        PhotonNetwork.Disconnect();
        //PhotonNetwork.LoadLevel(0);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
