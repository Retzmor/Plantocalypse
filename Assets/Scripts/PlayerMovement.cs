using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMovement : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rb;
    public float currenHealthPlayer;
    private float health = 100;
    [SerializeField] float movX = 0;
    [SerializeField] float movY = 0;
    [SerializeField] float velocityPlayer;
    [SerializeField] BarraVIda barraVida;
    [SerializeField] AudioClip muerte;
    [SerializeField] AudioClip recibirDaño;
    [SerializeField] AudioClip caminar;
    [SerializeField] float coolDown;
    [SerializeField] float coolDownPlayer;
    private float enfriamiento = -Mathf.Infinity;
    private float enfriamiento2 = -Mathf.Infinity;
    public float Health { get => health; set => health = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator AnimatorPlayer { get => _animator; set => _animator = value; }

    private void OnEnable()
    {
        TutorialManager.playerMovementDelegate += ActivacionRb;
    }

    public void OnDisable()
    {
        TutorialManager.playerMovementDelegate -= ActivacionRb;
    }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currenHealthPlayer = Health;
        Rb.bodyType = RigidbodyType2D.Static;
        barraVida.InicializarBarraVida(currenHealthPlayer);
    }

    // Update is called once per frame
    void Update()
    {  
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        float movimiento = movX + movY;

        if (movimiento != 0 && Time.time - coolDown >= enfriamiento && _rb.bodyType != RigidbodyType2D.Static)
        {
            ControladorAudios.Intance.EjecutarAudioUnaVez(caminar);
            enfriamiento = Time.time;

        }

        if (movimiento != 0)
        {
            _animator.SetBool("Movimiento", true);
            if (movX < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (movX > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

        else
        {
            _animator.SetBool("Movimiento", false);
        }
    }



    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(movX, movY) * velocityPlayer;
    }

    public void RecibirDaño(int damage)
    {
        currenHealthPlayer -= damage;
        barraVida.CambiarVidaActual(currenHealthPlayer);
        _animator.SetTrigger("Hit");
        if (currenHealthPlayer != 100 && Time.time - coolDownPlayer >= enfriamiento2)
        {
            ControladorAudios.Intance.EjecutarAudioUnaVez(recibirDaño);
            enfriamiento2 = Time.time;
        } 
        if (currenHealthPlayer <= 0)
        {
            Muerte("GameOver");
        }
    }

    private void Muerte(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ActivacionRb(bool rb)
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }

}