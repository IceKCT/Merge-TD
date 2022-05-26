using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    public static int Money;
    public int startMoney = 200;
    public Text moneyText;
    public int startLive = 100;
    public static int live;

    void Start()
    {
        Money = startMoney;
        live = startLive;
    }

    private void Update()
    {
        moneyText.text = Money.ToString();
    }

    public void getMoney(int amount)
    {
        Money += amount;
    }

    
}
