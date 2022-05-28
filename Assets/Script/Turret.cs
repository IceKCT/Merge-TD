using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("General")]
    public float range = 15f;

    [Header("Use Bullet (Defaul)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Water gun")]
    public bool useWater = false;
    public LineRenderer lineRenderer;
    public ParticleSystem effect;
    public int damageOverTime = 10;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 5f;

    [Header("SomeThing else")]
    public Transform firePoint;
    
    public int sellTower;
    public static float bonusFirerate = 0;
    public static int bonusDamage = 0;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
       
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            if (useWater)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    effect.Stop();
                }

            }
            return;
        }
            LockOnTarget();

            if (useWater)
            {
                Water();
            }
            else
            {
                if (fireCountdown <= 0)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate + bonusFirerate;
                }

                fireCountdown -= Time.deltaTime;
            }
        
       


    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Water()
    {
        
        target.GetComponent<Enemy>().TakeDamage((damageOverTime + bonusDamage) * Time.deltaTime);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            effect.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir = target.position - firePoint.position;
        effect.transform.position = target.position + dir.normalized * .5f;
        effect.transform.rotation = Quaternion.LookRotation(dir);

    }
    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public int GetMoneyFromTower()
    {
        return sellTower;
    }

    public static void HeroFirerate(float x , int y)
    {
        bonusFirerate = x;
        bonusDamage = y;
    }

}
