using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCompPerMatch : MonoBehaviour
{
    public List<GameObject> units;
    public List<GameObject> groups;
    public int groupSize = 3;
    void Start()
    {
        for (int i = 0; i < units.Count;i++)
        {
            GameObject temp = units[i];
            int randomIndex = Random.Range(i, units.Count);
            units[i] = units[randomIndex];
            units[randomIndex] = temp;
        }
        for (int i = 0; i < groupSize; i++)
        {
            groups.Add(units[i]);
        }
    }

}
