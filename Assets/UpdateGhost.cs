using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGhost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemy.GetComponent<Animator>().SetBool("isMoving", true);
            enemy.GetComponent<MoveToSound>().Search(transform);
            Destroy(gameObject);
        }
    }
}
