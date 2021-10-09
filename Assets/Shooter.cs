using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : BNG.Grabbable
{ public GameObject spawnPoint;
    public GameObject Projectile;
    public float launchVelocity = 500f;
    public bool readyToShoot;
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
     override public void Update()
    {
        
        
            


        if (BeingHeld == true && (input.RightTrigger > 0.1f) && readyToShoot)
        {
            var projectile = Instantiate(Projectile, spawnPoint.transform.position,Quaternion.identity);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * launchVelocity);
            readyToShoot = false;
            Invoke("ReReady", 2);

            
            
            
        }

    }
    public void ReReady()
    {
        readyToShoot = true;
    }
}
