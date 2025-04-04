using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 50;
    public float currentHealth;
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageTake(int newDamage)
    {
        Debug.Log("Recibiendo daño");
        currentHealth -= newDamage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
