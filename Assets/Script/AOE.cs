using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    [SerializeField]
    float radius = 10f;
    float damage = 1f;
    void Start()
    {
        InvokeRepeating("Dps", 1, 0.1f);
    }


    void Dps()
    {
        // QueryTriggerInteraction.Collide might be needed
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, radius);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("Hit");
                Enemy e = col.GetComponent<Enemy>();
                e.TakeDamage(damage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
