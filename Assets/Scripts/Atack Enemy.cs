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
     public void Attaking()
     {
       

     }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().RecibirDaño(damage);
        }
    }

   
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyPosition.position, radius);
    }
}
