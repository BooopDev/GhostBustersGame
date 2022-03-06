using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnTrigger : MonoBehaviour
{
    public GameObject[] toEnable;
    public bool destroyOnTrigger;
    public bool useDelay;
    public float delay;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(!useDelay)
            {
                foreach (GameObject obj in toEnable)
                {
                    obj.SetActive(true);
                }
                if (destroyOnTrigger)
                {
                    GetComponent<Collider>().enabled = false;
                }
            }
            else
            {
                Invoke("Delayed", delay);
            }
            
        }
    }

    private void Delayed()
    {
        foreach (GameObject obj in toEnable)
        {
            obj.SetActive(true);
        }
        if (destroyOnTrigger)
        {
            gameObject.SetActive(false);
        }
    }
}
