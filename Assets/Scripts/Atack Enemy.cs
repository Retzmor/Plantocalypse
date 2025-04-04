using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtackEnemy : MonoBehaviour
{
    Animation mushroom;
    public int damage = 10;
    [SerializeField] Transform enemyPosition;
    [SerializeField] float radius;
    
    
    

    void Start()
    {
        mushroom = GetComponent<Animation>();
        
    }


    void Update()
    {

    }

   

    public void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
            {
            other.GetComponent<PlayerMovement>().RecibirDaño(damage);
            }       
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyPosition.position, radius);
    }
}
