using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemigos = new List<GameObject>(); // Prefabs distintos
    [SerializeField] private int cantidadInicialPorPrefab = 5;
    [SerializeField] private int enemyLimit = 50;
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;
    [SerializeField] private PolygonCollider2D spawnArea;

    private float remainingTime;

    // Una lista de listas → cada sublista guarda enemigos del mismo tipo
    private List<List<GameObject>> poolListas = new List<List<GameObject>>();

    void Start()
    {
        InicializarPool();
        SetNextSpawnTime();
    }

    void Update()
    {
        if (TotalEnemigosActivos() >= enemyLimit) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            SpawnEnemy();
            SetNextSpawnTime();
        }
    }

    private void InicializarPool()
    {
        for (int i = 0; i < enemigos.Count; i++)
        {
            List<GameObject> lista = new List<GameObject>();

            for (int j = 0; j < cantidadInicialPorPrefab; j++)
            {
                GameObject obj = Instantiate(enemigos[i]);
                obj.SetActive(false);
                lista.Add(obj);
            }

            poolListas.Add(lista);
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPos = GetRandomPointInArea();

        int tipo = Random.Range(0, poolListas.Count);
        List<GameObject> lista = poolListas[tipo];
        GameObject enemigo = null;

        for (int i = 0; i < lista.Count; i++)
        {
            if (!lista[i].activeInHierarchy)
            {
                enemigo = lista[i];
                break;
            }
        }

        if (enemigo == null)
        {
            enemigo = Instantiate(enemigos[tipo]);
            enemigo.SetActive(false);
            lista.Add(enemigo);
        }

        enemigo.transform.position = spawnPos;
        enemigo.SetActive(true);
    }

    private int TotalEnemigosActivos()
    {
        int total = 0;

        for (int i = 0; i < poolListas.Count; i++)
        {
            List<GameObject> lista = poolListas[i];

            for (int j = 0; j < lista.Count; j++)
            {
                if (lista[j].activeInHierarchy)
                {
                    total++;
                }
            }
        }

        return total;
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
        }
        while (!spawnArea.OverlapPoint(point) && attempts < maxAttempts);

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
