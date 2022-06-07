using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStat : MonoBehaviour
{
    public static int Money;
    public int startMoney = 200;
    public Text moneyText;
    public Text scoreText;
    public int startLive = 100;
    public static int live = 0;
    public static int score;

    public static PlayerStat instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Money = startMoney;
        live = startLive;
        score = 0;
    }

    private void Update()
    {
        moneyText.text = Money.ToString();
        scoreText.text = score.ToString();

        if(live <= 0)
        {
            SceneManager.LoadScene("EndGameScene");
        }
    }

    public void getMoney(int amount)
    {
        Money += amount;
    }

    public void GetScore(int x)
    {
        score += x;
    }
    public void FinalScore()
    {;
        PlayerPrefs.SetInt("finalScore", score);
    }

    
}
