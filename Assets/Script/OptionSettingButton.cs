using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSettingButton : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject settingButton;
    

    public void OpenOption()
    {
        optionMenu.SetActive(true);
        settingButton.SetActive(false);
        Time.timeScale = 0f;
     
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
        Time.timeScale = 1f;
     
    }
}
