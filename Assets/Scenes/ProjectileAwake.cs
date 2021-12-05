using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAwake : MonoBehaviour
{
    
    Rigidbody rb;
    public float launchVelocity = 500f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(transform.forward * launchVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
