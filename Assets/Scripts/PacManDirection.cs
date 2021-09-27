using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManDirection : StateMachineBehaviour
{
    //public int Direction = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("CanTurn",false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetInteger("Direction", 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetInteger("Direction", 1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetInteger("Direction", 2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetInteger("Direction", 3);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animator.SetBool("CanTurn", true);// for debug, this bool should be true when PacMan hit a wall on the previous direction.
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("CanTurn",false);
    }

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
