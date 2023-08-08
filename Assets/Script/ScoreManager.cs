using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text finalScore;
    private int oldScore;
    // Start is called before the first frame update
    void Start()
    {
        oldScore = PlayerPrefs.GetInt("finalScore");
        finalScore.text = oldScore.ToString() + " Point." ;
    }
}
