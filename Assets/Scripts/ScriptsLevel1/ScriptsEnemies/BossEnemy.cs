using System.Collections.Generic;
using NUnit.Framework;
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
    [SerializeField] GameObject mushroomCurrent;

    public Animator AnimatorBoss { get => _animator; set => _animator = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = health;
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(CurrentHealth < 60 && !mushroomCurrent.activeSelf)
        {
            _animator.SetBool("Mush", true);
            mushroomCurrent.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if(estaActivo == false)
        {
            rb.linearVelocity = new Vector2(0, -5 * speed * Time.deltaTime);
            limitBottom.transform.position = new Vector2(0, -5 * speed * Time.deltaTime);
        }

        else if (estaActivo == true)
        {
            rb.linearVelocity = new Vector2(0, 5 * speed * Time.deltaTime);
            limitTop.transform.position = new Vector2(0, -5 * speed * Time.deltaTime);
        }
    }

    public void RecibirDaño(float damage)
    {
        _animator.SetTrigger("RecibirDaño");
        CurrentHealth -= damage;
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
