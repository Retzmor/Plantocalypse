using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] int curar = 30;
    [SerializeField] private AudioClip sonidoCuracion;
    private void Update()
    {
        transform.Rotate(new Vector3(0f, 10f, 0f) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            //ControladorAudios.Intance.EjecutarSonido(sonidoCuracion);
            collision.GetComponent<PlayerLvl1>().Curar(curar);
            gameObject.SetActive(false);
        }
    }
}
