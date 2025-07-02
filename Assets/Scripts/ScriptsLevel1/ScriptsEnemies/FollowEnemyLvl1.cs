using UnityEngine;

public class FollowEnemyLvl1 : StateMachineBehaviour
{
    CarnivoraLvl1 carniovora;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        carniovora = animator.GetComponent<CarnivoraLvl1>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 rotacionActual = carniovora.transform.localScale;
        float diferenciaX = carniovora.Player.transform.position.x - carniovora.transform.position.x;

        if (diferenciaX < 0)
        {
            carniovora.transform.localScale = new Vector3(Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        else if (diferenciaX > 0)
        {
            carniovora.transform.localScale = new Vector3(-Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        carniovora.Agent.SetDestination(carniovora.Player.transform.position);
    }
}
