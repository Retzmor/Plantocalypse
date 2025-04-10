using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private float spawnRangeX;
    [SerializeField] private float spawnRangeY;
    private float remainingTime;



    // Start is called before the first frame update
    void Awake()
    {
        SetRemainingTime();
    }

    // Update is called once per frame
    void Update()
    {
        float posXSpawn = Random.Range(-spawnRangeX, spawnRangeX);
        float posYSpawn = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 randomPosition = new Vector2(posXSpawn, posYSpawn);
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            Instantiate(Enemy, randomPosition, Enemy.transform.rotation);
            SetRemainingTime();
        }
    }

    private void SetRemainingTime()
    {
        remainingTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
