using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    //[SerializeField] private float spawnRangeX;
    //[SerializeField] private float spawnRangeY;
    [SerializeField] private int enemyLimit;
    public Transform positionDetect;
    public Vector2 sizeDetect;
    private float remainingTime;
    private int enemyCount;





    // Start is called before the first frame update
    void Awake()
    {
        SetRemainingTime();
    }

    // Update is called once per frame
    void Update()
    {
        float posXSpawn = Random.Range(-sizeDetect.x, sizeDetect.x);
        float posYSpawn = Random.Range(-sizeDetect.y, sizeDetect.y);
        Vector2 randomPosition = new Vector2(posXSpawn, posYSpawn);
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0 && enemyCount < enemyLimit)
        {
            Instantiate(Enemy, randomPosition, Enemy.transform.rotation);
            SetRemainingTime();
            enemyCount++;
        }
    }

    private void SetRemainingTime()
    {
        remainingTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(positionDetect.position, sizeDetect);
    }
}
