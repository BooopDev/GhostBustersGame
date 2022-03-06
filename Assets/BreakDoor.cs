using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDoor : MonoBehaviour
{
    public GrabCrowbar crowbar;
    public GameObject[] boards;

    public GameObject promptTextYes;
    public GameObject promptTextNo;
    private bool done;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !done)
        {
            if (crowbar.isComplete)
            {
                promptTextYes.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    done = true;
                    foreach(GameObject board in boards)
                    {
                        Destroy(board);
                    }
                }
            }
            else
            {
                promptTextNo.SetActive(true);
            }
        }
        else
        {
            promptTextNo.SetActive(false);
            promptTextYes.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            promptTextNo.SetActive(false);
            promptTextYes.SetActive(false);
        }
    }
}
