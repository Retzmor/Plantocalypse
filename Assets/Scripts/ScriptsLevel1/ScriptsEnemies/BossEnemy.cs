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
    [SerializeField] GameObject mushroomCurrent1;
    [SerializeField] GameObject mushroomCurrent2;
    [SerializeField] GameObject mushroomCurrent3;
    [SerializeField] GameObject mushroomCurrent4;
    [SerializeField] GameObject mushroomCurrent5;

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
        if(CurrentHealth == 100 && !mushroomCurrent1.activeSelf && !mushroomCurrent2.activeSelf)
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
       //_animator.SetTrigger("RecibirDaño");
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
