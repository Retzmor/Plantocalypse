using UnityEngine;
using UnityEngine.AI;

public class Carnivora : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _anim;

    [SerializeField] float health;
    [SerializeField] float _currentHealth;
    [SerializeField] GameObject zoneFollow;
    [SerializeField] float radiusAttack;
    [SerializeField] LayerMask _layermask;
    [SerializeField] GameObject _player;
    [SerializeField] TutorialManager manager;
    [SerializeField] AudioClip muerte;

    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public Animator Anim { get => _anim; set => _anim = value; }
    public GameObject Player { get => _player; set => _player = value; }
    public LayerMask LayermaskCarnivora { get => _layermask; set => _layermask = value; }
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        CurrentHealth = health;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        Collider2D zona = Physics2D.OverlapCircle(transform.position, radiusAttack, _layermask);
        if(zona) 
        {
            _anim.SetBool("Follow", zona);  
        }

        else
        {
            _anim.SetBool("Follow", false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHealth > 0)
        {
            _anim.SetTrigger("TakeDamage");
            CurrentHealth -= damage;
        }

        else
        {
            Die();
            ControladorAudios.Intance.EjecutarSonido(muerte);
        } 
    }

    public void Die()
    {
        _anim.SetBool("Death", true);
        manager.EnemigoDerrotado();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radiusAttack);
    }
}
