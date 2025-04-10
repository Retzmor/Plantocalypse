using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 50;
    Animator mushRoom;
    [SerializeField] bool takeDamage;
    [SerializeField] bool movement = true;
    [SerializeField] bool live = true;
    public float currentHealth;

    void Start()
    {
        mushRoom = GetComponent<Animator>();
        currentHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageTake(int newDamage)
    {
        Debug.Log("ME pegaron ome0");
        currentHealth -= newDamage;
        takeDamage = true;
        mushRoom.SetTrigger("Damage");
       
        
           
        if (currentHealth <= 0)
        {
            
            Death();
            
        }
    }

    

    public void Death()
    {

        live = false;
        mushRoom.SetBool("Vida", live);
      
    }
    public void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}
