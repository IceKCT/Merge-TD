using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;
        public Sprite spriteone, spriteTwo;
    }

    public static WaveSpawner instance;

    public Text textTimeCountBetweenSpawn;
    public Text currentWaveText;

    public Wave[] waves;

    public Transform SpawnPoint;
    public float timeBetweenWave;

    private Wave currentWave;
    private int currentWaveIndex;
    public GameObject hero;
    private bool finishedSpawn;

    private float countdown;
    private bool startWave = false;
    private Animator anim;

    public Image img1, img2, img3;

    public List<Enemy> enemylist = new List<Enemy>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one in scene");
            return;
        }
        instance = this;

    }

    private void Start()
    {
        countdown = timeBetweenWave;
        hero.SetActive(true);
        anim = textTimeCountBetweenSpawn.gameObject.GetComponent<Animator>();
    }
    
    public void MoneyHero()
    {
        Enemy.BonusHero(10);
        StartCoroutine(StartNextWave(currentWaveIndex));
        hero.SetActive(false);
    }
    public void FireRateHero()
    {
        Turret.HeroFirerate(0.2f , 10);
        StartCoroutine(StartNextWave(currentWaveIndex));
        hero.SetActive(false);
    }
    IEnumerator StartNextWave(int index)
    {
        startWave = true;
        yield return new WaitForSeconds(timeBetweenWave);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        startWave = false;

        currentWave = waves[index];

        img1.sprite = currentWave.spriteone;
        img2.sprite = currentWave.spriteTwo;
        for (int i = 0; i < currentWave.count; i++)
        {
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Instantiate(randomEnemy, SpawnPoint.position, SpawnPoint.rotation);
            enemylist.Add(randomEnemy);
            

            if(i == currentWave.count - 1)
            {
                finishedSpawn = true;
                
                //randomEnemy.Stronger(80 * Mathf.Sqrt(currentWaveIndex + 1));

            }
            else
            {
                finishedSpawn = false;
            }
            yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
        }
    }

    private void Update()
    {
       
        if (finishedSpawn == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            
            finishedSpawn = false;
            if(currentWaveIndex + 1 < waves.Length)
            {
                enemylist.Clear();
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                SceneManager.LoadScene("EndGameScene");
                Debug.Log("Game Finished");
            }
        }
        if (startWave == true)
        {
            textTimeCountBetweenSpawn.gameObject.SetActive(true);
            if (countdown >= 0)
            countdown -= Time.deltaTime;
            anim.SetBool("count", true);

        }
        else
        {
            textTimeCountBetweenSpawn.gameObject.SetActive(false);
            countdown = timeBetweenWave;
            anim.SetBool("count", false);
        }


        currentWaveText.text = (currentWaveIndex + 1).ToString();
        textTimeCountBetweenSpawn.text = Mathf.Floor(countdown).ToString();
    }
}
