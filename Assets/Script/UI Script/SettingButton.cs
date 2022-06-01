using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingButton : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingMenu;
    public void Back()
    {
        startMenu.SetActive(true);
        settingMenu.SetActive(false);
    }
    public void Setting()
    {
        settingMenu.SetActive(true);
        startMenu.SetActive(false);
    }


}
