using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExplosionb : MonoBehaviour
{
    public Rigidbody Target;
    public float explosionForce;
    public float blastRadius;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) 
        { 
            Target.AddExplosionForce(explosionForce, transform.position, blastRadius);
            print("funziona");
        }
    }
}
