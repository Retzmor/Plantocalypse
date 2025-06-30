using UnityEngine;
using UnityEngine.AI;

public class MushRoomEnemy : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    [SerializeField] float health;
    [SerializeField] float _currentHealth;
    [SerializeField] float speed;

    [SerializeField] float radiusDetected;
    [SerializeField] LayerMask layermask;
    [SerializeField] GameObject _target;
 
    public Animator AnimatorMushroom { get => _animator; set => _animator = value; }
    public GameObject Target { get => _target; set => _target = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public LayerMask LayermaskMushRoom { get => layermask; set => layermask = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        CurrentHealth = health;
    }

    private void FixedUpdate()
    {
        Collider2D zona = Physics2D.OverlapCircle(transform.position,radiusDetected, layermask);

        if (zona)
        {
            _animator.SetBool("Follow", zona);
        }

        else
        {
            _animator.SetBool("Follow", false);
        }
    }

    public void TakeDamage(int damage)
    { 
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damage;
            _animator.SetTrigger("TakeDamage");
        }

        else
        {
            _animator.SetBool("Death", true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radiusDetected);
    }
}
