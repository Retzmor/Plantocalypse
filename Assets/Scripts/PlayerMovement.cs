using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float currenHealthPlayer;
    public float health = 100;
    [SerializeField] float movX = 0;
    [SerializeField] float movY = 0;
    [SerializeField] float velocityPlayer;
    [SerializeField] BarraVIda barraVida;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currenHealthPlayer = health;
        barraVida.InicializarBarraVida(currenHealthPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movX, movY) * velocityPlayer;


    }

    public void RecibirDaño(int damage)
    {
        barraVida.CambiarVidaActual(currenHealthPlayer);
        currenHealthPlayer -= damage; 
        Debug.Log("El jugador recibió " + damage + " de daño. Salud restante: " + currenHealthPlayer);

    }

}