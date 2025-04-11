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
    public float tiempoEntreAtaques = 1.0f;
    float tiempoProximoAtaque = 0f;




    void Start()
    {
        mushroom = GetComponent<Animator>();

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time >= tiempoEntreAtaques)
        {
            mushroom.SetTrigger("attack");
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Time.time >= tiempoProximoAtaque)
        {
            //    mushroom.SetTrigger("attack");

            PlayerMovement jugador = collision.gameObject.GetComponent<PlayerMovement>();
            if (jugador != null)
            {
                jugador.RecibirDaño(damage);
            }

            tiempoProximoAtaque = Time.time + tiempoEntreAtaques;
        }
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemyPosition.position, radius);
    }
}
