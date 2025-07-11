using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class HidraEnemy : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    [SerializeField] GameObject _target;
    [SerializeField] float radius;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private float _speed;
    [SerializeField] private ScriptDialogue dialogue;
    [SerializeField] private GameObject enemigo1;
    [SerializeField] private GameObject enemigo2;
    [SerializeField] private TutorialManager tutorialManager;
    private float health = 100;
    [SerializeField] private float currentHealth;
    bool isDeath = false;
    [SerializeField] AudioClip muerte;
    [SerializeField] AudioClip recibirDaņo;


    public Animator AnimatorHidra { get => _animator; set => _animator = value; }
    public GameObject TargetHidra { get => _target; set => _target = value; }
    public float SpeedHidra { get => _speed; set => _speed = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public LayerMask LayerMaskHidra { get => _layerMask; set => _layerMask = value; }

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
        Collider2D zona = Physics2D.OverlapCircle(transform.position, radius, _layerMask);

        if (zona)
        {
            _animator.SetBool("Seguir", zona);
        }

        else
        {
            _animator.SetBool("Seguir", false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDeath) return; 
       
        if (currentHealth > 0)
        {
           
            CurrentHealth -= damage;
            _animator.SetTrigger("RecibirDaņo");
            ControladorAudios.Intance.EjecutarSonido(recibirDaņo);


        }

        else
        {
            isDeath = true;
            _animator.SetBool("Muerte", true);
            _animator.SetBool("Seguir", false);
            tutorialManager.EnemigoDerrotado();
            ControladorAudios.Intance.EjecutarSonido(muerte);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
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

   