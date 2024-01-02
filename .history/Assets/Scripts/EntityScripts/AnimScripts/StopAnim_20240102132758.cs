using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnim : StateMachineBehaviour
{
    public string animationName;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(animationName, false);
    }
}
