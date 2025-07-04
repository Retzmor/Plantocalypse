using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    Animator _animator;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = health;
        barravida.InicializarBarraVida(CurrentHealth);
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        coloresOriginales = new Color[spriteRenderers.Length];

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            coloresOriginales[i] = spriteRenderers[i].color;
        }
    }

    private void Update()
    {
        if (CurrentHealth < health && meMori == false)
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

        if (
     CurrentHealth == 100 &&
     mushroomCurrent1 != null && mushroomCurrent2 != null &&
     !mushroomCurrent1.activeSelf && !mushroomCurrent2.activeSelf
 )
        {
            _animator.SetTrigger("Mush");
            mushroomCurrent1.SetActive(true);
            mushroomCurrent2.SetActive(true);
        }
        else if (
     CurrentHealth == 60 &&
     mushroomCurrent3 != null && mushroomCurrent4 != null && mushroomCurrent5 != null &&
     !mushroomCurrent3.activeSelf && !mushroomCurrent4.activeSelf && !mushroomCurrent5.activeSelf
 )
        {
            _animator.SetTrigger("Mush");
            mushroomCurrent3.SetActive(true);
            mushroomCurrent4.SetActive(true);
            mushroomCurrent5.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (meMori) return; // Evita que se mueva después de morir

        float direccion = estaActivo ? 1f : -1f;
        Vector2 nuevaPosicion = rb.position + Vector2.up * direccion * speed * Time.fixedDeltaTime;
        rb.MovePosition(nuevaPosicion);
    }

    public void RecibirDaño(float damage)
    {
        if (!esVulnerable) return;
        CurrentHealth -= damage;
        barravida.CambiarVidaActual(CurrentHealth);

        if (currentHealth < 0)
        {
            _animator.SetBool("Death", true);
            damage = 0;
            meMori = true;
            randomGeneration.LiberarTodosLosEnemigos();
            AttackBoss attackScript = GetComponent<AttackBoss>();
            if (attackScript != null)
            {
                attackScript.enabled = false;
                attackScript.EliminarEnemigosInvocados();
            }
        }
    }

    public void ActivarVulnerabilidad(float duracion)
    {
        esVulnerable = true;

        foreach (var sr in spriteRenderers)
        {
            sr.color = Color.red; 

        StartCoroutine(DesactivarVulnerabilidad(duracion));
        }
    }

    private IEnumerator DesactivarVulnerabilidad(float duracion)
    {
        yield return new WaitForSeconds(duracion);
        esVulnerable = false;

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].color = coloresOriginales[i];
        }
    }

    public void SerInnmune()
    {
        ActivarVulnerabilidad(3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("colisionAbajo"))
        {
            estaActivo = true;
        }

        else if(other.CompareTag("colisionArriba"))
        {
            estaActivo = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(limitTop.transform.position, radius);
        Gizmos.DrawWireSphere(limitBottom.transform.position, radius);

    }
}
