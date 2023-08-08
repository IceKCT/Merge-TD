using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    [Header("WINDOW")]
    [SerializeField] GameObject infoWindow;
    [Header("INFO")]
    [SerializeField] GameObject monsterInfo;
    [SerializeField] GameObject cardInfo1;
    [SerializeField] GameObject cardInfo2;
    [Header("BUTTON")]
    [SerializeField] GameObject hamburgerButton;

    public void CardInfoButton()
    {
        monsterInfo.SetActive(false);
        cardInfo2.SetActive(false);
        cardInfo1.SetActive(true);
    }
    public void MoreCardInfoButton()
    {
        cardInfo1.SetActive(false);
        cardInfo2.SetActive(true);
    }
    public void MonsterInfoButton()
    {
        cardInfo1.SetActive(false);
        cardInfo2.SetActive(false);
        monsterInfo.SetActive(true);
    }
    public void CloseInfoButton()
    {
        infoWindow.SetActive(false);
        hamburgerButton.SetActive(true);
    }
    public void OpenInfoButton()
    {
        hamburgerButton.SetActive(false);
        infoWindow.SetActive(true);
    }
}
