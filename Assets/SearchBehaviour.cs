using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBehaviour : StateMachineBehaviour
{
    private AudioSource source;
    public AudioClip clip;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<MoveToSound>().CancelInvoke();
        animator.GetComponent<MoveToSound>().StopAllCoroutines();
        source = animator.GetComponent<AudioSource>();
        source.Stop();
        source.clip = clip;
        source.Play();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
