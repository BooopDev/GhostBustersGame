using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
    public AudioClip locked;
    public AudioClip open;
    public AudioClip close;
    private AudioSource source;
    private Animator anim;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if(!isLocked && !anim.GetBool("IsOpen"))
        {
            anim.SetBool("IsOpen", true);
            source.PlayOneShot(open);
        }
        else if(anim.GetBool("IsOpen"))
        {
            anim.SetBool("IsOpen", false);
            source.PlayOneShot(close);
        }
        else
        {
            anim.SetTrigger("Locked");
            source.PlayOneShot(locked);
        }
    }
}
