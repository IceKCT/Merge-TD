using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildTower : MonoBehaviour
{
    Buildmanager buildManager;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderOBJ;
    [SerializeField] private GameObject dciPanel;
    [SerializeField] private GameObject Alert;
    public GameObject tower;
    public float buildProgress;
    public float maxTime;
    public bool onProgress;
    private int timeCount;
    ResearchUI research;
    PlayerStat stat;
    
    private void Start()
    {
        stat = PlayerStat.instance;
        research = GetComponent<ResearchUI>();
        buildManager = Buildmanager.instance;
        buildProgress = maxTime;
        onProgress = false;
        
    }
    public void OnBuildButton()
    {
        
        if (onProgress==false)
        {
            if (buildProgress<=maxTime)
            {
                dciPanel.SetActive(true);
                Debug.Log("Bruh");
              
            }
        }
        else
        {
            if (buildProgress <= 0)
            {
                buildProgress = maxTime;
                onProgress = false;
                Debug.Log("Get Tower");
                buildManager.SelectTurretToBuild(tower);
                //research.movePos();
                Debug.Log("gotchaBitch");
                Alert.SetActive(false);
            }
            else
            {
                Debug.Log("Cant");
            }
        }
    }
    public void OnYesButton()
    {
        sliderOBJ.SetActive(true);
        buildProgress = maxTime;
        dciPanel.SetActive(false);
        onProgress = true;
        Debug.Log("Start CountDown");
        InvokeRepeating("CountDown", 1f, 1f);
        Debug.Log(buildProgress);
    }
    public void OnNoButton()
    {
        dciPanel.SetActive(false);
    }
    private void Update()
    {
        if(buildProgress <= 0 && onProgress == false)
        {
            Alert.SetActive(true);
        }
    }

    private void CountDown()
    {
        if (buildProgress > 0)
        {
            
            buildProgress -= 1;
            Debug.Log("Buildprogress = "+ buildProgress);
            slider.value = buildProgress / maxTime;
           
        }
        else
        {

            sliderOBJ.SetActive(false);
            
        }
    }
}
