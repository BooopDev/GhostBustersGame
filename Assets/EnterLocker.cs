using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLocker : MonoBehaviour
{
    public float reach;
    public LayerMask mask;
    public GameObject promptText;
    public GameObject escapeText;
    private GameObject lockerCamera;
    public static bool inLocker;

    private bool canWork = false;

    private void Start()
    {
        inLocker = false;
        canWork = false;
        Invoke("Delay", 0.5f);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach, mask))
        {
            promptText.SetActive(true);

            lockerCamera = hit.collider.GetComponent<LockerData>().camera;

            if(Input.GetKeyDown(KeyCode.E))
            {
                inLocker = true;
                lockerCamera.SetActive(true);
                promptText.SetActive(false);
                escapeText.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        else
        {
            promptText.SetActive(false);
        }
    }

    void Delay()
    {
        canWork = true;
    }
}
