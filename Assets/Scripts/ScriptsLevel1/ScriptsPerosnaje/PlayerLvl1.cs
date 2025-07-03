using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLvl1 : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _animator;
    public float currenHealthPlayer;
    private float health = 120;
    [SerializeField] float movX = 0;
    [SerializeField] float movY = 0;
    [SerializeField] float velocityPlayer;
    [SerializeField] BarraVIda barraVida;
    //[SerializeField] AudioClip muerte;
    //[SerializeField] AudioClip recibirDaño;
    //[SerializeField] AudioClip caminar;
    [SerializeField] float coolDown;
    [SerializeField] float coolDownPlayer;
    private float enfriamiento2 = -Mathf.Infinity;
    public float Health { get => health; set => health = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator Animator { get => _animator; set => _animator = value; }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currenHealthPlayer = Health;
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        float movimiento = movX + movY;

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
            //ControladorAudios.Intance.EjecutarAudioUnaVez(caminar);
            //enfriamiento = Time.time;   
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
        barraVida.CambiarVidaActual(currenHealthPlayer);
        if (currenHealthPlayer != 100 && Time.time - coolDownPlayer >= enfriamiento2)
        {
            //ControladorAudios.Intance.EjecutarAudioUnaVez(recibirDaño);
            enfriamiento2 = Time.time;
        }
        currenHealthPlayer -= damage;
        if (currenHealthPlayer <= 0)
        {
            Muerte("GameOver");
        }
    }

    public void Curar(int cura)
    {
        currenHealthPlayer += cura;
        barraVida.CambiarVidaActual(currenHealthPlayer);
    }

    private void Muerte(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
