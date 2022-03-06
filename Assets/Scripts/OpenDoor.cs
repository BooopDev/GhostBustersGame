using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float range;
    public GameObject text;
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.collider.CompareTag("Door"))
            {
                text.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Door>().OpenDoor();
                }
            }
            else
            {
                text.SetActive(false);
            }
        }
        else
        {
            text.SetActive(false);
        }
    }
}
