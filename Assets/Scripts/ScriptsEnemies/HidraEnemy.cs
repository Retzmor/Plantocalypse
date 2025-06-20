using Unity.VisualScripting;
using UnityEngine;

public class HidraEnemy : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] GameObject gizmo;
    [SerializeField] GameObject gizmoAttack;
    [SerializeField] float radius;
    [SerializeField] float radiusAttack;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float _speed;
    Rigidbody2D _rb;
    Animator _animator;
    private float health = 100;
    private int damage = 10;
    private float currentHealth = 100;
    [SerializeField] private float attackCooldown = 0.5f;
    private float enfriamientoAtaque = -Mathf.Infinity;     


    public Rigidbody2D RbHidra { get => _rb; set => _rb = value; }
    public Animator AnimatorHidra { get => _animator; set => _animator = value; }
    public GameObject TargetHidra { get => _target; set => _target = value; }
    public float SpeedHidra { get => _speed; set => _speed = value; }
    public int Damage { get => damage; set => damage = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        CurrentHealth = health;
    }

    private void FixedUpdate()
    {
        Collider2D zona = Physics2D.OverlapCircle(transform.position, radius, layerMask);

        if (zona)
        {
            _animator.SetBool("Seguir", zona);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        _animator.SetTrigger("RecibirDaño");
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            _animator.SetBool("Muerte", true);
            _animator.SetBool("Atacar", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement jugador = collision.GetComponent<PlayerMovement>();

            if (jugador != null && Time.time - enfriamientoAtaque >= attackCooldown)
            {
                jugador.RecibirDaño(damage);
                enfriamientoAtaque = Time.time;
            }

            _animator.SetBool("Atacar", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _animator.SetBool("Atacar", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

   