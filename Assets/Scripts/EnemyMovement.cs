using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Animator murshroom;
    Enemy enemy;
    [SerializeField] float VelocityEnemyFollow = 2.5f;
    [SerializeField] bool ubication;
    [SerializeField] bool activation = false;
    [SerializeField] public float movement;
    [SerializeField] bool idle;
    [SerializeField] Transform player;
    

    

    public bool follow;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        murshroom = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow && player != null)
        {
            Vector2 direction = player.position - transform.position;  
            transform.position = Vector2.MoveTowards(transform.position, player.position, VelocityEnemyFollow * Time.deltaTime);
            Vector3 currentScale = transform.localScale;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
            }
        }
        murshroom.SetFloat("Velocidad", movement);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Estoy en el collider");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Estoy en el if");
            follow = true;
            if (follow == true && enemy.currentHealth != 0)
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
            follow = false;
            murshroom.SetBool("Movimiento", idle);
        }
    }
}
