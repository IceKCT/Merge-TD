using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingButton : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingMenu;
    public List<ResItem> resolution = new List<ResItem>();
    private int selectedResolution;
    public Text resolutionText;
    public Toggle fullscreenTog, vsyncTog;
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }
        bool findRes = false;
        for (int i = 0 ; i < resolution.Count; i++)
        {
            if (Screen.width == resolution[i].horizontal && Screen.height == resolution[i].vertical)
            {
                findRes = true;
                selectedResolution = i;
                UpdateResolution();
            }
        }
        if (!findRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;
            resolution.Add(newRes);
            selectedResolution = resolution.Count - 1;
            UpdateResolution();
        }
    }
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
    public void ApplyChange()
    {
        //Screen.fullScreen = fullscreenTog.isOn;
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolution[selectedResolution].horizontal, resolution[selectedResolution].vertical,fullscreenTog.isOn);
    }
    public void RestLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResolution();
    }
    public void RestRight()
    {
        selectedResolution++;
        if (selectedResolution > resolution.Count - 1)
        {
            selectedResolution = resolution.Count - 1;
        }
        UpdateResolution();
    }
    public void UpdateResolution()
    {
        resolutionText.text = resolution[selectedResolution].horizontal.ToString() + " x " + resolution[selectedResolution].vertical.ToString();
    }
}
[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
