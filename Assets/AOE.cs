using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    float radius = 10f;
    float damage = 2f;
    void Start()
    {
        InvokeRepeating("Dps", 1, 3);
    }


    void Dps()
    {
        // QueryTriggerInteraction.Collide might be needed
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);

        foreach (Collider col in hitColliders)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(damage);
            }
        }
    }
}
