using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
   
    public float explosionRadius = 0;
    public float attackDamage;
    private Enemy enemy;

    public static float attackBonus = 0;

    public GameObject AOEPrefab;
    public bool isAOE = false;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void HitTarget()
    {


        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {

        }
        Damage(target);
        Destroy(gameObject);
        AOE();
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(attackDamage);
        }
        
    }
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    void AOE()
    {
        if (isAOE == true)
        {
            var cloneAOE = Instantiate(AOEPrefab, transform.position, Quaternion.identity);
            Destroy(cloneAOE, 5.0f);
        }
        
    }
}
