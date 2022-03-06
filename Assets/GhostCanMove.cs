using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCanMove : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<MoveToSound>().canMove = true;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<MoveToSound>().Invoke("RandomLocation",Random.Range(5,10f));
        }
    }
}
