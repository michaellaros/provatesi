using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMine : MonoBehaviour
{
    public float destroyTime;
    public GameObject fire;
    public GameObject particle;
    public float fireDamage;
    public Vector3 explosionDistance;
    public void FixedUpdate()
    {
        if(transform.position.y < explosionDistance.y)
        {
            Instantiate(particle, transform.position, transform.rotation);
            Instantiate(fire, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}   
