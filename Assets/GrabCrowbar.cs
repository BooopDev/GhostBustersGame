using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCrowbar : MonoBehaviour
{
    public GameObject promptText;
    public GameObject objective;
    public bool isComplete;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && !isComplete)
        {
            promptText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                isComplete = true;
                promptText.SetActive(false);
                objective.SetActive(true);
            }
        }
        else
        {
            promptText.SetActive(false);
        }
    }
}
