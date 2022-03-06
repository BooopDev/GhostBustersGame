using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveForceOnEnable : MonoBehaviour
{
    public float force;
    public float radius;
    void Start()
    {
        foreach(Transform obj in transform)
        {
            obj.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position + Vector3.up, radius);
        }
    }
}
