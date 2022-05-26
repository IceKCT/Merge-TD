using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float timeBetweenSpawn;
    }

    public Text textTimeCountBetweenSpawn;

    public Wave[] waves;

    public Transform SpawnPoint;
    public float timeBetweenWave;

    private Wave currentWave;
    private int currentWaveIndex;

    private bool finishedSpawn;

    private void Start()
    {
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWave);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        for (int i = 0; i < currentWave.count; i++)
        {
            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Instantiate(randomEnemy, SpawnPoint.position, SpawnPoint.rotation);

            if(i == currentWave.count - 1)
            {
                finishedSpawn = true;
                randomEnemy.Stronger(80 * Mathf.Sqrt(currentWaveIndex + 1));
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
        if(finishedSpawn == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finishedSpawn = false;
            if(currentWaveIndex + 1 < waves.Length)
            {
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
            }
            else
            {
                SceneManager.LoadScene("EndGameScene");
                Debug.Log("Game Finished");
            }
        }

        
        
    }
}
