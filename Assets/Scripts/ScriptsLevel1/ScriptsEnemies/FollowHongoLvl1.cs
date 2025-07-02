using UnityEngine;

public class FollowHongoLvl1 : StateMachineBehaviour
{
    HongoLvl1 mushRoomEnemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        mushRoomEnemy = animator.GetComponent<HongoLvl1>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector3 rotacionActual = mushRoomEnemy.transform.localScale;
        float diferenciaX = mushRoomEnemy.Target.transform.position.x - mushRoomEnemy.transform.position.x;

        if (diferenciaX > 0)
        {
            mushRoomEnemy.transform.localScale = new Vector3(Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        else if (diferenciaX < 0)
        {
            mushRoomEnemy.transform.localScale = new Vector3(-Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        mushRoomEnemy.Agent.SetDestination(mushRoomEnemy.Target.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
