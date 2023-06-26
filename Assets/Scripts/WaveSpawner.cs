using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;

    public Transform spawnPoint;
    public float time_of_waves = 5f;
    
    public static float wave_countdown;
    public float wave_start_countdown = 5;

    void Start()
    {
        wave_countdown = wave_start_countdown;
    }

    void Update()
    {
        if (GameStates.OnMenu == true)
        {
            return;
        }

        if (wave_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            wave_countdown = time_of_waves;
        }

        wave_countdown -= Time.deltaTime;

        wave_countdown = Mathf.Clamp(wave_countdown, 0f, Mathf.Infinity);

    }

    IEnumerator SpawnWave()
    {
        GameManager.instance.IncreaseWaveNumber(1);
        
        for (int i = 0; i < GameManager.instance.GetWaveNumber(); i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        GameEvents.NewEnemyCreated();
    }
}