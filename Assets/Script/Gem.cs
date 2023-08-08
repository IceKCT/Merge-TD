using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public GameObject self;
    BaseTower tower;
    public List<BaseTower> towerInMap = new List<BaseTower>();
    public LayerMask auraTower;
    void Start()
    {
        tower = GetComponent<BaseTower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
