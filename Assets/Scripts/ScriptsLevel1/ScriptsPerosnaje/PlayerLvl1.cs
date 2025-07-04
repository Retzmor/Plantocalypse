using Unity.PlasticSCM.Editor.WebApi;
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
    [SerializeField] AudioClip recibirDaño;
    //[SerializeField] AudioClip caminar;
    [SerializeField] float coolDown;
    [SerializeField] float coolDownPlayer;
    [SerializeField] GameObject cura;
    [SerializeField] GameObject curaPlayer;
    [SerializeField] GameObject curaPlayer2;
    public bool curar = false;
    public bool curar2 = false;
    public bool curar3 = false;
    private float enfriamiento2 = -Mathf.Infinity;
    [SerializeField] private AudioClip clipPasos;
    public float Health { get => health; set => health = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }
    public Animator Animator { get => _animator; set => _animator = value; }

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currenHealthPlayer = Health;
        barraVida.InicializarBarraVida(currenHealthPlayer);
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
            //ControladorAudios.Intance.ReproducirPasos(clipPasos);
        }

        else
        {
            //ControladorAudios.Intance.DetenerPasos();
            _animator.SetBool("Movimiento", false);
        }

        if (currenHealthPlayer == 60 && curar)
        {
            cura.SetActive(true);
        }

        if (currenHealthPlayer == 20 && curar2)
        {
            cura.SetActive(true);
        }

        if (currenHealthPlayer == 40 && curar3)
        {
            cura.SetActive(true);
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
        if (currenHealthPlayer != 100 && Time.time - coolDownPlayer >= enfriamiento2)
        {
            //ControladorAudios.Intance.EjecutarAudioUnaVez(recibirDaño);
            enfriamiento2 = Time.time;
        }
        if (currenHealthPlayer <= 0)
        {
            Muerte("GameOver");
        }
    }

    public void CurarActivar()
    {
        curar = true;
        curar2 = true;
        curar3 = true;
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
