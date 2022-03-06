using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour
{
    public AudioClip sound;
    [Range(0,1)]
    public float volume;
    void Start()
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 0;
        source.maxDistance = 15;
        source.PlayOneShot(sound);
    }

}
