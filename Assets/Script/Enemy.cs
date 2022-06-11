using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 5f;
    private Transform target;
    private int wavepointIndex = 0;
    public float starthealth = 100;
    private float health,healthDivine;
    public int worth = 10;
    public int scoreAmount;
    public Image healthBar;
    private PlayerStat p;
    public int enemyDamage;
    public static int bonusMoney;
    private float increaseHealthPerWave = 10;
    WaveSpawner wave;
    [Header("ItemDroper")]
    public bool hasItemTodrop;
    public GameObject dropItem;

    private void Start()
    {
        wave = WaveSpawner.instance;
        target = Waypoints.points[0];
        Stronger();
        health = starthealth + increaseHealthPerWave;
        healthDivine = health;
        p = GetComponent<PlayerStat>();
        
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / healthDivine;
        if(health <= 0)
        {
            Die();
        }
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWayPoints();
        }


    }

    void GetNextWayPoints()
    {

        if(wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void Die()
    {
        if (hasItemTodrop)
        {
            int x = Random.Range(0, 100);
            if (x <= 20)
            {
                Instantiate(dropItem, transform.position, Quaternion.identity);
            }
        }
        
        PlayerStat.Money += worth + bonusMoney;
        PlayerStat.score += scoreAmount;
        Destroy(gameObject);
    }

    public static int BonusHero(int x)
    {
        return bonusMoney = x;
    }

    void EndPath()
    {
        PlayerStat.live -= enemyDamage;
        
        Destroy(gameObject);
    }

    public void Stronger()
    {
        increaseHealthPerWave = 10 + (10 * Mathf.Sqrt(increaseHealthPerWave + wave.currentWaveIndex));
    }
}
