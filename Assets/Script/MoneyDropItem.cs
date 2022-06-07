using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDropItem : MonoBehaviour
{
    public int moneyAmount;

    private void OnMouseDown()
    {
        PlayerStat.Money += moneyAmount;
        Destroy(gameObject);
    }
}
