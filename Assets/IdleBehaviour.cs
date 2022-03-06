using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
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
        animator.GetComponent<MoveToSound>().Invoke("RandomTurn",Random.Range(0f,10f));
        if(animator.GetComponent<MoveToSound>().canMove)
        {
            animator.GetComponent<MoveToSound>().Invoke("RandomLocation", Random.Range(5f, 20f));
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<MoveToSound>().StopAllCoroutines();
        animator.GetComponent<MoveToSound>().CancelInvoke();
    }
}
