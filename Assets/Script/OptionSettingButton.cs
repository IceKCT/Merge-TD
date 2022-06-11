using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSettingButton : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject settingButton;
    public static bool isGamePause = false;

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
            
        }
    }
    public void OpenOption()
    {
        optionMenu.SetActive(true);
        settingButton.SetActive(false);
        Time.timeScale = 0f;
        isGamePause = true;
     
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
}
