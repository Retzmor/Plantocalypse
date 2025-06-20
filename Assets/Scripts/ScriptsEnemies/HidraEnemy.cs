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
    private float health;
    private int damage = 10;
    private float currentHealth;

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

    public void TakeDamage(int dmg)
    {
        CurrentHealth -= dmg;
        _animator.SetTrigger("Hurt");          
        if (CurrentHealth <= 0)
        _animator.SetTrigger("Die");       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Estoy en el istrigger");
            _animator.SetTrigger("Atacar");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}