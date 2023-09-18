using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject[] enemyPrefabsPerWave; 
    public Transform spawnPoint;

    public float timeBetweenEnemies = 1.0f;
    public float waveDuration = 60.0f;
    public float timeBetweenWaves = 12.0f;

    private bool spawning = true;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        int currentWave = 0;

        while (currentWave < enemyPrefabsPerWave.Length && spawning)
        {
            GameObject enemyPrefab = enemyPrefabsPerWave[currentWave];
            
          
            float timeElapsed = 0f;
            while (timeElapsed < waveDuration)
            {
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(timeBetweenEnemies);
                timeElapsed += timeBetweenEnemies;
            }

            currentWave++;
            

            if (currentWave < enemyPrefabsPerWave.Length)
                yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void StopSpawning()
    {
        spawning = false;
    }
}