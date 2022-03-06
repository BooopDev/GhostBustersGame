using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    public float searchRange;
    public LayerMask mask;
    public Material highlight;
    public Material rock;

    private MeshRenderer mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (Physics.CheckSphere(transform.position, searchRange, mask))
        {
            mat.material = highlight;
        }
        else
        {
            mat.material = rock;
        }
    }
}
