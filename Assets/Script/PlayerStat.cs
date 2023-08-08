using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
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
    public float FinalMoney;
    public int FinalHealth;
    public int FinalScore;
    public GameObject finalScoreWindow;
    public GameObject handPanel;
    public GameObject tapPanel;
    public bool isGameEnd;
    [SerializeField] Transform playerBestScoreTable;
    [SerializeField] GameObject playerBestScoreInGame;
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
        isGameEnd = false;
    }

    private void Update()
    {
        
        moneyText.text = Mathf.Floor(Money).ToString();
        scoreText.text = score.ToString();

        if(live <= 0)
        {
            live = 0;
            if (isGameEnd == false)
            {   
                isGameEnd = true;
                SendLeaderBoard(FinalScore);
                GetYourBestScore();
            }
            finalScoreWindow.SetActive(true);
            handPanel.SetActive(false);
            tapPanel.SetActive(false);

        }

        Money += (monpersec + bonusMoney) * Time.deltaTime;
        PlayerPrefs.SetString("SCORE", score.ToString());
        PlayerPrefs.SetString("MONEY", Money.ToString());
        PlayerPrefs.SetString("HEALTH", live.ToString());
    }

    public void getMoney(float amount)
    {
        Money += amount;
        
    }

    public void GetScore(int x)
    {
        score += x;
    }

    public static void GetBonusMoney(int x)
    {
        bonusMoney = x;
    } 
    
    public void playAnimation()
    {
        anim.SetTrigger("Damage");
    }
    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate
                {
                    StatisticName = "GameScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }
    public void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully leader board sent");
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    public void GetYourBestScore()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "GameScore",
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnYourBestScoreGet, OnError);
    }
    public void OnYourBestScoreGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in playerBestScoreTable)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject playerInfo = Instantiate(playerBestScoreInGame, playerBestScoreTable);
            Text[] texts = playerInfo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();
        }
    }
}
