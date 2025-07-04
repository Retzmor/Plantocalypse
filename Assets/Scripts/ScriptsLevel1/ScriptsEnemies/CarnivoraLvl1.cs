using UnityEngine;
using UnityEngine.AI;

public class CarnivoraLvl1 : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _anim;

    [SerializeField] float health;
    [SerializeField] float _currentHealth;
    [SerializeField] LayerMask _layermask;
    [SerializeField] GameObject _player;
    [SerializeField] AudioClip muerte;
    private bool isDeath = false;

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
    public void TakeDamage(int damage)
    {
        if (isDeath) return;
        if (CurrentHealth > 0)
        {
            _anim.SetTrigger("TakeDamage");
            CurrentHealth -= damage;
        }

        else
        {
            isDeath = true;
            Die();
           ControladorAudios.Intance.EjecutarSonido(muerte);
        }
    }

    public void Die()
    {
        _anim.SetBool("Death", true);
    }

}
