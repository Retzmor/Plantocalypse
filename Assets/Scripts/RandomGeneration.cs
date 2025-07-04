using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RandomGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemigos = new List<GameObject>();
    [SerializeField] private int cantidadInicialPorPrefab;
    [SerializeField] private int enemyLimit;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private PolygonCollider2D spawnArea;

    private List<ObjectPool<GameObject>> pools = new List<ObjectPool<GameObject>>();

    // Conteo de enemigos activos por prefab
    private List<int> activosPorPrefab = new List<int>();

    private void Start()
    {
        // Crear un pool para cada tipo de enemigo
        for (int i = 0; i < enemigos.Count; i++)
        {
            int index = i; // Para capturar correctamente el índice en las lambdas
            activosPorPrefab.Add(0); // Inicializar el contador

            ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    GameObject obj = Instantiate(enemigos[index]);
                    obj.GetComponent<Enemy>().SetPool(this, index);
                    obj.SetActive(false);
                    return obj;
                },
                actionOnGet: (obj) =>
                {
                    obj.SetActive(true);
                    activosPorPrefab[index]++;
                },
                actionOnRelease: (obj) =>
                {
                    obj.SetActive(false);
                    activosPorPrefab[index]--;
                },
                actionOnDestroy: (obj) =>
                {
                    Destroy(obj);
                },
                collectionCheck: false,
                defaultCapacity: cantidadInicialPorPrefab,
                maxSize: enemyLimit
            );

            pools.Add(pool);
        }

        // Comenzar ciclo de aparición
        Invoke(nameof(SpawnEnemy), Random.Range(minSpawnTime, maxSpawnTime));
    }

    private void SpawnEnemy()
    {
        if (TotalActivos() >= enemyLimit)
        {
            Invoke(nameof(SpawnEnemy), Random.Range(minSpawnTime, maxSpawnTime));
            return;
        }

        int randomIndex = Random.Range(0, pools.Count);
        Vector2 spawnPosition = GetRandomPointInCollider(spawnArea);

        GameObject enemigo = pools[randomIndex].Get();
        enemigo.transform.position = spawnPosition;

        Invoke(nameof(SpawnEnemy), Random.Range(minSpawnTime, maxSpawnTime));
    }

    public void ReleaseEnemy(GameObject enemigo, int poolIndex)
    {
        if (poolIndex >= 0 && poolIndex < pools.Count)
        {
            pools[poolIndex].Release(enemigo);
        }
    }

    private int TotalActivos()
    {
        int total = 0;
        for (int i = 0; i < activosPorPrefab.Count; i++)
        {
            total += activosPorPrefab[i];
        }
        return total;
    }

    public void DetenerGeneracion()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }

    public void LiberarTodosLosEnemigos()
    {
        for (int i = 0; i < enemigos.Count; i++)
        {
            Enemy[] enemigosActivos = FindObjectsOfType<Enemy>();

            foreach (Enemy enemigo in enemigosActivos)
            {
                if (enemigo.poolIndex == i)
                {
                    pools[i].Release(enemigo.gameObject);
                }
            }
        }
    }



    private Vector2 GetRandomPointInCollider(PolygonCollider2D collider)
    {
        Bounds bounds = collider.bounds;
        Vector2 point;
        int attempts = 0;

        do
        {
            point = new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
            );
            attempts++;
        } while (!collider.OverlapPoint(point) && attempts < 100);

        return point;
    }
}
