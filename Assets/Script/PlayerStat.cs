using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStat : MonoBehaviour
{
    public static float Money;
    public float startMoney = 200;
    public Text moneyText;
    public Text scoreText;
    public int startLive = 100;
    public static int live = 0;
    public static int score;
    private int monpersec = 0;
    public static int bonusMoney;
    public  Animator anim;
    public GameObject Live;
    public static PlayerStat instance;
    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        
        Money = startMoney;
        live = startLive;
        score = 0;
    }

    private void Update()
    {
        
        moneyText.text = Mathf.Floor(Money).ToString();
        scoreText.text = score.ToString();

        if(live <= 0)
        {
            SceneManager.LoadScene("EndGameScene");
        }

        Money += (monpersec + bonusMoney) * Time.deltaTime;
    }

    public void getMoney(float amount)
    {
        Money += amount;
    }

    public void GetScore(int x)
    {
        score += x;
    }
    public void FinalScore()
    {
        PlayerPrefs.SetInt("finalScore", score);
    }

    public static void GetBonusMoney(int x)
    {
        bonusMoney = x;
    } 
    
    public void playAnimation()
    {
        anim.SetTrigger("Damage");
    }
}
