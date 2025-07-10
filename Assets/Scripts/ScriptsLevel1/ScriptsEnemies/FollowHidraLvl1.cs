using UnityEngine;

public class FollowHidraLvl1 : StateMachineBehaviour
{
    HidraLvl1 HidraEnemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HidraEnemy = animator.GetComponent<HidraLvl1>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 rotacionActual = HidraEnemy.transform.localScale;
        float diferenciaX = HidraEnemy.TargetHidra.transform.position.x - HidraEnemy.transform.position.x;

        if (diferenciaX > 0)
        {
            HidraEnemy.transform.localScale = new Vector3(Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        else if (diferenciaX < 0)
        {
            HidraEnemy.transform.localScale = new Vector3(-Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        HidraEnemy.Agent.SetDestination(HidraEnemy.TargetHidra.transform.position);
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
