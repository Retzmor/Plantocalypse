using UnityEngine;
using UnityEngine.AI;

public class HongoLvl1 : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    [SerializeField] float health;
    [SerializeField] float _currentHealth;
    private bool isDeath = false;
    [SerializeField] LayerMask layermask;
    [SerializeField] GameObject _target;
    //[SerializeField] AudioClip muerte;


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


    public void TakeDamage(int damage)
    {
        if (isDeath) return;
        if (CurrentHealth > 0)
        {
            CurrentHealth -= damage;
            _animator.SetTrigger("TakeDamage");
            
        }

        else
        {
            isDeath = true;
            _animator.SetBool("Death", true);
           // ControladorAudios.Intance.EjecutarSonido(muerte);
        }
    }
}
