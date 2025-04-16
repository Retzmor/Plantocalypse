using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void RecibirDa�o(int damage)
    {
        barraVida.CambiarVidaActual(currenHealthPlayer);
        currenHealthPlayer -= damage;
        
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