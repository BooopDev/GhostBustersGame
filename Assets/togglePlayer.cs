using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class togglePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject playercam;
    public GameObject escapeText;
    private bool canWork = false;

    private void Start()
    {
        canWork = false;
        Invoke("Delay", 0.5f);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canWork)
        {
            EnterLocker.inLocker = false;
            player.SetActive(true);
            escapeText.SetActive(false);
            playercam.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void Delay()
    {
        canWork = true;
    }
}
