using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public List<Wave> waves;
    public Transform player;

    private int currentWave = 0;
    private List<GameObject> activeEnemies = new();

    // Some zombies where spawning below the map and falling infinitely, this should fix that.
    // Might wanna add a kill zone beneath the map.
    private float spawnYOffset = 3f;

    private void Start()
    {
        foreach (Wave w in waves)
        {
            if (w.enemyPrefab != null) PoolManager.Instance.Register(w.enemyPrefab, w.count);
        }

        StartCoroutine(WaveLoop());
    }

    private IEnumerator WaveLoop()
    {
        while (true)
        {
            currentWave = (currentWave) % waves.Count;
            Wave wave = waves[currentWave++];

            SpawnWave(wave);
            float timer = wave.timer;
            while (timer > 0f)
            {
                timer -= Time.deltaTime;
                yield return null;
            }

            yield return null;
        }
    }

    private void SpawnWave(Wave w)
    {
        for (int i = 0; i < w.count; i++)
        {
            Vector2 circle = Random.insideUnitCircle.normalized * w.radius;
            Vector3 position = player.position + new Vector3(circle.x, spawnYOffset, circle.y);

            GameObject enemy = PoolManager.Instance.Spawn(
                w.enemyPrefab,
                position,
                Quaternion.LookRotation(player.position - position)
            );

            activeEnemies.Add(enemy);
        }
    }
}
