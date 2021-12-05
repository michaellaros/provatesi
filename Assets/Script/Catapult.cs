using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public GameObject rock;
    public GameObject spawn;
    Animator anim;
    public bool power;
    public float launchVelocity;
    bool readyToShoot;
    bool launchProjectile;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToShoot && Input.GetKeyDown(KeyCode.A))
            anim.SetBool("launch", true);
        if (Input.GetKeyUp(KeyCode.A))
            anim.SetBool("launch", false);
        if (readyToShoot && Input.GetKeyDown(KeyCode.A))
        {
            power = true; 
        }
        else
        {
            power = false;
        }

        if (power)
        {
            
            var instanceRock = Instantiate(rock, spawn.transform.position, spawn.transform.rotation);
            instanceRock.GetComponent<Rigidbody>().AddForce(spawn.transform.forward * launchVelocity);
            readyToShoot = false;
            Invoke("ReReady", 2);
        }
        
        
    }
    public void ReReady()
    {
        readyToShoot = true;
    }
}
