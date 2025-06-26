using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyLimit;
    public float anchoArea;
    public float alturaArea;
    public float minSpawnTime;
    public float maxSpawnTime;

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
        float x = Random.Range(-anchoArea / 2f, anchoArea / 2f);
        float y = Random.Range(-alturaArea / 2f, alturaArea / 2f);
        return (Vector2)transform.position + new Vector2(x, y);
    }

    private void SetNextSpawnTime()
    {
        remainingTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(anchoArea, alturaArea, 0));
    }
}
