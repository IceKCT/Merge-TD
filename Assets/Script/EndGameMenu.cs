using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Game is exit");
    }
}
