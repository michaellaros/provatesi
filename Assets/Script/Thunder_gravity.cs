using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder_gravity : MonoBehaviour

{
    private GameObject attractedTo;
    public float strengthOfAttraction = 5.0f;
    private bool gravity;
    private Vector3 direction;
    void FixedUpdate()
    {
        if (gravity)
        {
            direction = attractedTo.transform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(strengthOfAttraction * direction);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tesla"))
        
        {
            attractedTo = collision.gameObject;
            gravity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tesla"))
        {
            gravity = false;
        }
    }

}
