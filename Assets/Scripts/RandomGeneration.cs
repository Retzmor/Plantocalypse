using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyLimit;
    public float minSpawnTime;
    public float maxSpawnTime;
    public PolygonCollider2D spawnArea;

    private float remainingTime;
    private int currentEnemyCount = 0;

    private void Start()
    {
        SetNextSpawnTime();
    }

    private void Update()
    {
        if (currentEnemyCount >= enemyLimit) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            SpawnEnemy();
            SetNextSpawnTime();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition = GetRandomPointInArea();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemyCount++;
    }

    private Vector2 GetRandomPointInArea()
    {
        Bounds bounds = spawnArea.bounds;
        Vector2 point = Vector2.zero;
        int attempts = 0;
        int maxAttempts = 100;

        do
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            point = new Vector2(x, y);
            attempts++;
        } while (!spawnArea.OverlapPoint(point) && attempts < maxAttempts);

        if (attempts >= maxAttempts)
        {
            Debug.LogWarning("No se pudo encontrar un punto válido dentro del área de spawn.");
        }

        return point;
    }

    private void SetNextSpawnTime()
    {
        remainingTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnArea != null)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < 10; i++)
            {
                Vector2 testPoint = GetRandomPointInArea();
                Gizmos.DrawSphere(testPoint, 0.1f);
            }
        }
    }
}
