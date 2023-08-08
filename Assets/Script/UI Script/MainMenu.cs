using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionWindow;
    [SerializeField] GameObject menuWindow;
    public void QuitGameButton()
    {
        Application.Quit();
    }
    public void OptionButton()
    {
        optionWindow.SetActive(true);
        menuWindow.SetActive(false);
    }
}
