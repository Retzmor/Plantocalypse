using UnityEngine;

public class AttackHidra : StateMachineBehaviour
{
    HidraEnemy hidra;
    PlayerMovement player;
    bool damageApplied;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hidra = animator.GetComponent<HidraEnemy>();
        player = hidra.TargetHidra.GetComponent<PlayerMovement>();
        damageApplied = false;
        hidra.RbHidra.linearVelocity = Vector2.zero;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!damageApplied && stateInfo.normalizedTime >= 0.5f)
        {
            player.RecibirDaño(hidra.Damage);
            damageApplied = true;
        }
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
