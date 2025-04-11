using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Zona : MonoBehaviour
{
    [SerializeField] Vector3 size;

    public Vector3 GetRandomPosition()
    {
        Debug.Log("xD");
        float randomXposition = Random.Range(transform.position.x - (size.x / 2), transform.position.x + (size.x / 2));
        float randomYposition = Random.Range(transform.position.y - (size.y / 2), transform.position.y + (size.y / 2));
        return new Vector3(randomXposition, randomYposition, transform.position.z);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(GetRandomPosition());
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
