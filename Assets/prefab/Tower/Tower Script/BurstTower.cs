using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstTower : MonoBehaviour
{
    private Transform target;

    [Header("General")]
    public float range = 15f;
    public float attackDamage;

    [Header("Use Bullet (Defaul)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 5f;

    [Header("SomeThing else")]
    public Transform firePoint;

    TowerInput towerInput;
    public GameObject uiTower;

    void Start()
    {
        uiTower = GameObject.Find("TowerUI");
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        Stack<GameObject> nearestEnemys = new Stack<GameObject>(3);



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

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BurstBullet bullet = bulletGo.GetComponent<BurstBullet>();

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


    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            LockOnTarget();
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }


    }

    public void OnMouseDown()
    {

        uiTower.transform.position = new Vector3(960, 540, 0);
        towerInput.SelectTowerTarget(this.gameObject);
    }
}
