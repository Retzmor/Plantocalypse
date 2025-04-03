using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] int velocityEnemy = 2;
    [SerializeField] float VelocityEnemyFollow = 2.5f;
    [SerializeField] bool ubication;
    [SerializeField] bool activation = false;
    [SerializeField] Transform player;
    public bool follow;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
       
        
    }

    // Update is called once per frame
    void Update()
    {


        if (rigid.position.x > 1 && ubication == false)
        {
            
            rigid.velocity = new Vector2(-velocityEnemy, 0);
            if (rigid.position.x <= 2)
            {
                Debug.Log("Ubicacion verdader");
                ubication = true;

            }
        }

        else if (ubication == true)
        {
            Debug.Log("Me estoy moviendo a la derecha");
            rigid.velocity = new Vector2(velocityEnemy, 0);
            if (rigid.position.x >= 13)
            {
                Debug.Log("Ubicacion falsa");
                ubication = false;

            }
        }

        if (follow && player != null)
        {
            velocityEnemy = 0;
            transform.position = Vector2.MoveTowards(transform.position, player.position,VelocityEnemyFollow * Time.deltaTime);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            follow = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            velocityEnemy = 4;
            follow = false;
            
        }
    }

}
