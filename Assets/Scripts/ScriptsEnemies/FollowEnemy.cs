using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FollowEnemy : StateMachineBehaviour
{
    HidraEnemy HidraEnemy;
    Animator anim;
    Rigidbody2D rb;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HidraEnemy = animator.GetComponent<HidraEnemy>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        Vector2 direccion = (HidraEnemy.TargetHidra.transform.position - rb.transform.position).normalized;
        Vector2 nuevaDireccion = rb.position + direccion * HidraEnemy.SpeedHidra * Time.fixedDeltaTime;
        rb.MovePosition(nuevaDireccion);

        Vector3 rotacionActual = rb.transform.localScale;
        float diferenciaX = HidraEnemy.TargetHidra.transform.position.x - rb.transform.position.x;

        if (diferenciaX < 0)
        {
            rb.transform.localScale = new Vector3(Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
        }
        else if (diferenciaX > 0)
        {
            rb.transform.localScale = new Vector3(-Mathf.Abs(rotacionActual.x), rotacionActual.y, rotacionActual.z);
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
