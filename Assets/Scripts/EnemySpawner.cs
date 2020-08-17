using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float waitTimeBeforeSpawns = 0f;
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;

    int enemiesInWave;

    Level level;

    IEnumerator Start()
    {
        level = FindObjectOfType<Level>();
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currWaveCount = waveConfigs[waveIndex];
            level.AddEnemies(currWaveCount.GetNumberOfEnemies());
        }
        yield return new WaitForSeconds(waitTimeBeforeSpawns);
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator WaitinSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
