using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayer : MonoBehaviour
{
    public bool pausePlayer;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    private void Update()
    {
        if(pausePlayer)
        {
            controller.enabled = false;
        }
        else
        {
            controller.enabled = true;
        }
    }
}
