using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("SpearMaster_Attack_1", false);
    }
}
