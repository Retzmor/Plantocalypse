using UnityEngine;

public class Enemy : MonoBehaviour
{
    private RandomGeneration poolManager;
    public int poolIndex;

    public void SetPool(RandomGeneration manager, int index)
    {
        poolManager = manager;
        poolIndex = index;
    }

    public void Morir()
    {
        poolManager.ReleaseEnemy(this.gameObject, poolIndex);
    }
}