using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Fionda : BNG.Grabbable
{   public GameObject spawnPoint;
    public GameObject Projectile;
    public float launchVelocity;
    public bool readyToShoot;
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
     override public void Update()
    {
        if (readyToShoot && BeingHeld == true && (input.RightTrigger > 0.1f))
        {
            var projectile = Instantiate(Projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * launchVelocity);
            readyToShoot = false;
            Invoke("ReReady", 2);
        }
    }
    public void ReReady()
    {
        readyToShoot = true;
    }
}
