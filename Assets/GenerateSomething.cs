using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSomething : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    public void GenerateButton()
    {
        var cloneCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
