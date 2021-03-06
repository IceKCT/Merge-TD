using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionSettingButton : MonoBehaviour
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
        Time.timeScale = 0f;
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
        Time.timeScale = 1f;
    }
    public void ResumeGameTwo()
    {
        optionMenu.SetActive(false);
        settingButton.SetActive(true);
        SettingPanel.SetActive(false);
        isGamePause = false;
        isGameSetting = false;
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("samplescene");
    }

    
}
