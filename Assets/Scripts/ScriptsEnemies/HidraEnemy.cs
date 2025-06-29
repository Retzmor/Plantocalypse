using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class HidraEnemy : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    [SerializeField] GameObject _target;
    [SerializeField] GameObject gizmo;
    [SerializeField] GameObject gizmoAttack;
    [SerializeField] float radius;
    [SerializeField] float radiusAttack;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float _speed;
    [SerializeField] private ScriptDialogue dialogue;
    [SerializeField] private GameObject enemigo1;
    [SerializeField] private GameObject enemigo2;
    [SerializeField] private TutorialManager tutorialManager;
    private float health = 100;
    private int damage = 10;
    private float currentHealth = 100;
    //private bool enemigoMuerto = false;
    //private bool dialogoMostrado = false;
    [SerializeField] private float attackCooldown = 0.5f;
    private float enfriamientoAtaque = -Mathf.Infinity;     


    public Animator AnimatorHidra { get => _animator; set => _animator = value; }
    public GameObject TargetHidra { get => _target; set => _target = value; }
    public float SpeedHidra { get => _speed; set => _speed = value; }
    public int Damage { get => damage; set => damage = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }

    void Start()
    {
            CurrentHealth = health;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void FixedUpdate()
    {
        Collider2D zona = Physics2D.OverlapCircle(transform.position, radius, layerMask);

        if (zona)
        {
            _animator.SetBool("Seguir", zona);
        }

        else
        {
            _animator.SetBool("Seguir", false);
        }
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        _animator.SetTrigger("RecibirDaño");
        if (CurrentHealth <= 0)
        {
            _animator.SetBool("Muerte", true);
            tutorialManager.EnemigoDerrotado();
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

            _animator.SetTrigger("Atacar");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

 

    public void ActivarEnemigosFase2()
    {
        enemigo1.SetActive(true);
        enemigo2.SetActive(true);
    }
}

   