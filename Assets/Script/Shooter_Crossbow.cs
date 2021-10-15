﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Crossbow : BNG.Grabbable
{
    
    public Vector3 startPos;
    public GameObject spawnPoint;
    public GameObject Projectile;
    public float launchVelocity;
    public bool readyToShoot;
    void Start()
    {
        startPos = transform.position;
        readyToShoot = true;
    }

    // Update is called once per frame
    override public void Update()
    {
        

        if (!BeingHeld)
        {
            transform.position = startPos;
        }
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