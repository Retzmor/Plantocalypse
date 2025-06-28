using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementMush : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float speed;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
