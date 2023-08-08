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
    public Text textCountdownInWave;

    public Wave[] waves;

    public Transform SpawnPoint;
    public float timeBetweenWave;

    private Wave currentWave;
    public int currentWaveIndex;
    public GameObject hero;
    private bool finishedSpawn;

    private float countdown;
    public float timeInWave;
    public float stableTimeinWave;
    private bool startWave = false;
    private bool endTime = false;
    private Animator anim;

    public Image img1, img2, img3;

    public List<Enemy> enemylist = new List<Enemy>();

    public GameObject selectElementUI;

    public GameObject hand;

    private Enemy enemy;

    public GameObject merchantPanel, KnightPanel;

    public bool isHeroSelect;
    public bool isGameStart;
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
        enemy = GetComponent<Enemy>();
        selectElementUI.SetActive(true);
    }


    IEnumerator StartNextWave(int index)
    {
        startWave = true;
        timeInWave = stableTimeinWave;
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

            if (i == currentWave.count - 1)
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

        if (finishedSpawn == true && endTime == true)
        {

            finishedSpawn = false;
            endTime = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                enemylist.Clear();
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                Debug.Log("Game Finished");
            }
        }
        if (startWave == true)
        {
            textTimeCountBetweenSpawn.gameObject.SetActive(true);
            if (countdown >= 0)
                countdown -= Time.deltaTime;
            if (countdown <= 3)
            {
                FindObjectOfType<AudioManager>().Play("StartWave");
            }

        }
        else
        {
            textTimeCountBetweenSpawn.gameObject.SetActive(false);
            countdown = timeBetweenWave;


            if (timeInWave > 0)
            {
                textCountdownInWave.gameObject.SetActive(true);
                timeInWave -= Time.deltaTime;

            }
            else
            {
                endTime = true;
                textCountdownInWave.gameObject.SetActive(false);
            }

            //anim.SetBool("count", false);
        }



        currentWaveText.text = (currentWaveIndex + 1).ToString();
        textCountdownInWave.text = Mathf.Floor(timeInWave).ToString();
        textTimeCountBetweenSpawn.text = Mathf.Floor(countdown).ToString();
        if (isHeroSelect == true && Timer.instance.timerisover == true && isGameStart == false)
        {
            startWave = true;
            StartCoroutine(StartNextWave(currentWaveIndex));
            hand.SetActive(true);
            isGameStart = true;
        }
        if (PlayerStat.instance.isGameEnd == true)
        {
            StopAllCoroutines();
        }
    }
    public void MerchantHero()
    {
        countdown = timeBetweenWave;
        isHeroSelect = true;
        anim = textTimeCountBetweenSpawn.gameObject.GetComponent<Animator>();       
        selectElementUI.SetActive(false);
        merchantPanel.SetActive(true);
        Enemy.BonusHero(10);
    }

    public void KnightHero()
    {
        countdown = timeBetweenWave;
        isHeroSelect = true;
        anim = textTimeCountBetweenSpawn.gameObject.GetComponent<Animator>();
        selectElementUI.SetActive(false);
        KnightPanel.SetActive(true);
        BaseTower.knightOn = true;
    }
}
