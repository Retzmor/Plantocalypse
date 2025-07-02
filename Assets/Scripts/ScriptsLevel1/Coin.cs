using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] int curar = 30;
    private void Update()
    {
        transform.Rotate(new Vector3(0f, 10f, 0f) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hice collision");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Estoy en el if");
            collision.GetComponent<PlayerLvl1>().Curar(curar);
            Destroy(gameObject);
        }
    }
}
