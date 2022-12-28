using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraBuff : MonoBehaviour
{
    public float auraRadius = 20f;
    public bool isAura = false;
    private void Start()
    {
        if (isAura == true)
        {
            Aura();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, auraRadius);
    }
    void Aura()
    {
        // QueryTriggerInteraction.Collide might be needed
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, auraRadius);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Turret")
            {
                Debug.Log("GetAura");
                Turret t = col.GetComponent<Turret>();
                t.attackDamage += 20;
            }
        }
    }
}
