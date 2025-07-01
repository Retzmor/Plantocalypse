using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLvl1 : MonoBehaviour
{
    Rigidbody2D _rb;
    public float currenHealthPlayer;
    private float health = 100;
    [SerializeField] float movX = 0;
    [SerializeField] float movY = 0;
    [SerializeField] float velocityPlayer;
    [SerializeField] BarraVIda barraVida;
    //[SerializeField] AudioClip muerte;
    //[SerializeField] AudioClip recibirDaño;
    //[SerializeField] AudioClip caminar;
    [SerializeField] float coolDown;
    [SerializeField] float coolDownPlayer;
    private float enfriamiento = -Mathf.Infinity;
    private float enfriamiento2 = -Mathf.Infinity;
    public float Health { get => health; set => health = value; }
    public Rigidbody2D Rb { get => _rb; set => _rb = value; }


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        currenHealthPlayer = Health;
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

        //float movimiento = movX + movY;

        //if (movimiento != 0 && Time.time - coolDown >= enfriamiento)
     //   {
            //ControladorAudios.Intance.EjecutarAudioUnaVez(caminar);
          //  enfriamiento = Time.time;

        //}
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(movX, movY) * velocityPlayer;
    }

    public void RecibirDaño(int damage)
    {
        if (currenHealthPlayer != 100 && Time.time - coolDownPlayer >= enfriamiento2)
        {
            //ControladorAudios.Intance.EjecutarAudioUnaVez(recibirDaño);
            enfriamiento2 = Time.time;
        }
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
