using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpThrowable : MonoBehaviour
{
    public float reach;
    public float scanRange;
    public LayerMask mask;

    public GameObject promptText;
    public TMPro.TextMeshProUGUI counter;
    public Material highlightMat;
    public Material rockMat;

    private Collider[] throwables;
    private GameObject closestObj;
    private GameObject toPickUp;
    private GameObject oldObj;

    private int count;


    public Slider chargeBar;
    private float force;
    public float chargeAmount;
    private bool throwing;
    public GameObject brick;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, reach, mask))
        {
            promptText.SetActive(true);
            throwables = Physics.OverlapSphere(hit.point, scanRange, mask);

            if (throwables != null)
            {
                float nearestDist = Mathf.Infinity;
                closestObj = null;

                for (int i = 0; i < throwables.Length; i++)
                {
                    Vector3 offset = throwables[i].transform.position - transform.position;
                    float sqrLength = offset.sqrMagnitude;
                    if (sqrLength < nearestDist * nearestDist)
                    {
                        closestObj = throwables[i].gameObject;
                    }
                }
            }
        }
        else
        {
            promptText.SetActive(false);
        }

        if(oldObj != null && oldObj != closestObj)
        {
            oldObj.GetComponent<MeshRenderer>().material = rockMat;
        }

        if(closestObj != null && closestObj.GetComponent<MeshRenderer>().material != highlightMat)
        {
            oldObj = closestObj;
            closestObj.GetComponent<MeshRenderer>().material = highlightMat;
        }

        if(Input.GetMouseButtonDown(0) && closestObj != null)
        {
            count++;
            counter.text = "throwables: " + count.ToString();
            Destroy(closestObj); 
        }

        if(Input.GetMouseButtonDown(1) && count > 0)
        {
            throwing = true;
        }
        if(throwing)
        {
            force += Mathf.Clamp01((chargeAmount / 100)) * Time.deltaTime;

            chargeBar.value = force;
        }
        if(Input.GetMouseButtonUp(1) && count > 0)
        {
            throwing = false;
            count--;
            counter.text = "throwables: " + count.ToString();
            GameObject thrown = Instantiate(brick, transform.position, Random.rotation);
            thrown.GetComponent<Rigidbody>().AddForce((transform.TransformDirection(Vector3.forward) * 1000) * force);
            force = 0;
            chargeBar.value = force;

        }
    }
}

