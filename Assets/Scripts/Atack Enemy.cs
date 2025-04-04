using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AtackEnemy : MonoBehaviour
{
    Animator mushroom;
    public int damage = 10;
    [SerializeField] Transform enemyPosition;
    [SerializeField] float radius;
    
    
    

    void Start()
    {
        mushroom = GetComponent<Animator>();
        
    }


    void Update()
    {

    }
     public void Attaking()
     {
       

     }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mushroom.SetTrigger("attack");
            collision.gameObject.GetComponent<PlayerMovement>().RecibirDaño(damage);
        }
    }

   
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyPosition.position, radius);
    }
}
