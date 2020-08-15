using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float waitTimeBeforeSpawns = 0f;
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = true;
    [SerializeField] bool loadNextLevelAfterThis = false;
    [SerializeField] float TimeBeforeLoadNextLevel = 0;

    Level level;

    IEnumerator Start()
    {
        level = FindObjectOfType<Level>();
        yield return new WaitForSeconds(waitTimeBeforeSpawns);
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);

        yield return new WaitForSeconds(TimeBeforeLoadNextLevel);

        if (loadNextLevelAfterThis)
        {
            level.LoadNextLevel();
        }
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
