using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float ExtraGravity = 0;
    public Vector3 ExtraForce;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ExtraGravity == 0)
            return;

        Vector3 grav = Vector3.up * ExtraGravity;
        _rigidbody.AddForce(grav, ForceMode.Force);
    }
}
