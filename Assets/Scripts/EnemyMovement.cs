using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator murshroom;
    [SerializeField] int velocityEnemy = 2;
    [SerializeField] float VelocityEnemyFollow = 2.5f;
    [SerializeField] bool ubication;
    [SerializeField] bool activation = false;
    [SerializeField] float movement;
    [SerializeField] bool idle;
    [SerializeField] Transform player;
    public bool follow;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        murshroom = GetComponent<Animator>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

       

        if (follow && player != null)
        {
            velocityEnemy = 3;
            transform.position = Vector2.MoveTowards(transform.position, player.position,VelocityEnemyFollow * Time.deltaTime);
            
        }

        murshroom.SetFloat("Velocidad", movement);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            follow = true;
            if (follow == true)
            {
                idle = true;
                movement = 2;
                murshroom.SetBool("Movimiento", idle);

                
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            idle = false;
            movement = 0;
            velocityEnemy = 4;
            follow = false;
            murshroom.SetBool("Movimiento", idle);

        }
    }



}
