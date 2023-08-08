using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDefault : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float attackdamage;

    private Enemy enemy;
    public void Seek(Transform target_)
    {
        target = target_;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public virtual void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }

    public void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(attackdamage);
        }

    }
}
