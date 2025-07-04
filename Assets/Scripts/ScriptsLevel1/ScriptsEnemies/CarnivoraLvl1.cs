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

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }
    void Start()
    {
        CurrentHealth = health;
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
            gameObject.SetActive(false);
            //ControladorAudios.Intance.EjecutarSonido(muerte);
        }
    }
    public void Death()
    {
        gameObject.SetActive(false);
    }

}
