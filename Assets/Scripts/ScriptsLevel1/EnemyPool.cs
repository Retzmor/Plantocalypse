using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    private RandomGeneration poolManager;
    public int poolIndex;
    private Vector3 escalaOriginal;

    public Animator Anim { get => anim; set => anim = value; }
    public NavMeshAgent Agent { get => agent; set => agent = value; }

    private void Awake()
    {
        escalaOriginal = transform.localScale;
    }

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    public void SetPool(RandomGeneration manager, int index)
    {
        poolManager = manager;
        poolIndex = index;
    }

    public void Morir()
    {
        gameObject.SetActive(false); 


        poolManager.ReleaseEnemy(gameObject, poolIndex);
    }

    public void ReiniciarEstado()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play("Follow", 0, 0f);
    }

    public void ReiniciarTransform(Vector2 nuevaPosicion)
    {
        transform.position = nuevaPosicion;

        transform.eulerAngles = new Vector3(0, 0, 0);

        transform.localScale = escalaOriginal;
    }
}