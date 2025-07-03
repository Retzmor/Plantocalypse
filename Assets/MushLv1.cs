using UnityEngine;
using UnityEngine.AI;

public class MushLv1 : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;
    [SerializeField] PlayerLvl1 playerLvl1;
    [SerializeField] GameObject target;
    [SerializeField] GameObject zonaExplosion;
    [SerializeField] float radius;
    [SerializeField] int damage;
    [SerializeField] LayerMask player;

    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public Animator Animator { get => _animator; set => _animator = value; }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(target.transform.position);
    }

    private void FixedUpdate()
    {
        Collider2D zona = Physics2D.OverlapCircle(zonaExplosion.transform.position,radius,player);

        if (zona)
        {
            _animator.SetTrigger("Explosion");   
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(zonaExplosion.transform.position,radius);
    }

    public void Destruir()
    {
        playerLvl1.RecibirDaño(damage);
        Destroy(gameObject);
    }
}
