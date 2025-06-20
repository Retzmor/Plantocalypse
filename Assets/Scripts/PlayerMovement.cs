using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float currenHealthPlayer;
    private float health = 100;
    [SerializeField] float movX = 0;
    [SerializeField] float movY = 0;
    [SerializeField] float velocityPlayer;
    [SerializeField] BarraVIda barraVida;

    public float Health { get => health; set => health = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currenHealthPlayer = Health;
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movX, movY) * velocityPlayer;
    }

    public void RecibirDaño(int damage)
    {
        barraVida.CambiarVidaActual(currenHealthPlayer);
        currenHealthPlayer -= damage;
        Debug.Log("El jugador recibi� " + damage + " de da�o. Salud restante: " + currenHealthPlayer);
        if (currenHealthPlayer <= 0)
        {
            Muerte("GameOver");
        }
    }

    private void Muerte(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}