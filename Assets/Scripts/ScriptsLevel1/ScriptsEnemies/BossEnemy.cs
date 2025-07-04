using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator _animator;
    [SerializeField] float health = 120;
    [SerializeField] float currentHealth;
    [SerializeField] float speed;
    [SerializeField] GameObject limitTop;
    [SerializeField] GameObject limitBottom;
    [SerializeField] float radius;
    [SerializeField] bool estaActivo = false;
    [SerializeField] GameObject mushroomCurrent1;
    [SerializeField] GameObject mushroomCurrent2;
    [SerializeField] GameObject mushroomCurrent3;
    [SerializeField] GameObject mushroomCurrent4;
    [SerializeField] GameObject mushroomCurrent5;
    [SerializeField] RandomGeneration randomGeneration;
    [SerializeField] BarraVIda barravida;

    private bool esVulnerable = false;
    private bool meMori = false;
    private float tiempoAcumulado = 0f;

    private SpriteRenderer[] spriteRenderers;
    private Color[] coloresOriginales;

    public Animator AnimatorBoss { get => _animator; set => _animator = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        CurrentHealth = health;
        barravida.InicializarBarraVida(CurrentHealth);
       
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        coloresOriginales = new Color[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            coloresOriginales[i] = spriteRenderers[i].color;
        }
    }

    void Update()
    {
        if (CurrentHealth < health && !meMori)
        {
            tiempoAcumulado += Time.deltaTime;
            if (tiempoAcumulado >= 1f)
            {
                CurrentHealth += 2;
                if (CurrentHealth > health)
                    CurrentHealth = health;

                barravida.CambiarVidaActual(CurrentHealth);
                tiempoAcumulado = 0f;
            }
        }

        if (CurrentHealth == 100 && !mushroomCurrent1.activeSelf && !mushroomCurrent2.activeSelf)
        {
            _animator.SetTrigger("Mush");
            mushroomCurrent1.SetActive(true);
            mushroomCurrent2.SetActive(true);
        }
        else if (CurrentHealth == 60 && !mushroomCurrent3.activeSelf && !mushroomCurrent4.activeSelf && !mushroomCurrent5.activeSelf)
        {
            _animator.SetTrigger("Mush");
            mushroomCurrent3.SetActive(true);
            mushroomCurrent4.SetActive(true);
            mushroomCurrent5.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (estaActivo == false)
        {
            rb.linearVelocity = new Vector2(0, -5 * speed * Time.deltaTime);
            
        }

        else if (estaActivo == true)
        {
            rb.linearVelocity = new Vector2(0, 5 * speed * Time.deltaTime);
            
        }
    }

    public void RecibirDaño(float damage)
    {
        if (!esVulnerable) return;

        CurrentHealth -= damage;
        barravida.CambiarVidaActual(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            _animator.SetBool("Death", true);
            meMori = true;
            CambioDeEscena();
        }
    }

    public void ActivarVulnerabilidad(float duracion)
    {
        esVulnerable = true;
        if (spriteRenderers == null || spriteRenderers.Length == 0)
        {
            Debug.LogWarning("No se encontraron SpriteRenderers en el boss.");
        }
        else
        {
            foreach (var sr in spriteRenderers)
            {
                sr.color = Color.red;
            }
        }
            
        StartCoroutine(DesactivarVulnerabilidad(duracion));
    }

    IEnumerator DesactivarVulnerabilidad(float duracion)
    {
        yield return new WaitForSeconds(duracion);
        esVulnerable = false;

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = coloresOriginales[i];
        }
    }

    public void CambioDeEscena()
    {
        GameAdministrator.Instance.StageChange("Final");
    }

    public void SerInnmune()
    {
        ActivarVulnerabilidad(3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("colisionAbajo"))
        {
            estaActivo = true;
        }
        else if (other.CompareTag("colisionArriba"))
        {
            estaActivo = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(limitTop.transform.position, radius);
        Gizmos.DrawWireSphere(limitBottom.transform.position, radius);
    }
}

