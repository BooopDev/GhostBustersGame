using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnImpact : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;
    public Vector3 pingPos;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1.5f)
        {
            if(Vector3.Distance(transform.position, enemy.transform.position) < collision.relativeVelocity.magnitude * 3)
            {
                enemy.GetComponent<Animator>().SetBool("isMoving", true);
                enemy.GetComponent<MoveToSound>().Search(transform);
            }
            source.PlayOneShot(clips[Random.Range(0, clips.Length)], collision.relativeVelocity.magnitude / 10);
        }
    }
}
