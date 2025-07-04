using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class HidraLvl1 : MonoBehaviour
{
    Animator _animator;
    NavMeshAgent _agent;
    [SerializeField] GameObject _target;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private float health;
    private float currentHealth;
    bool isDeath = false;
    //[SerializeField] AudioClip muerte;
    [SerializeField] AudioClip recibirDaño;


    public Animator AnimatorHidra { get => _animator; set => _animator = value; }
    public GameObject TargetHidra { get => _target; set => _target = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public LayerMask LayerMaskHidra { get => _layerMask; set => _layerMask = value; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
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

        if (currentHealth > 0)
        {

            CurrentHealth -= damage;
            _animator.SetTrigger("RecibirDaño");
            //ControladorAudios.Intance.EjecutarSonido(recibirDaño);
        }

        else
        {
            isDeath = true;
            gameObject.SetActive(false);
           // ControladorAudios.Intance.EjecutarSonido(muerte);
        }
    }

    public void Death()
    {
        gameObject.SetActive(false);
    }
}
