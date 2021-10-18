﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public GameObject cannon;
    //proiettile
    [SerializeField]
    private GameObject bullet;
    private Transform instanceBullet;
    //obiettivo da sparare, se null, la torretta non spara
    private GameObject target;
    
    [SerializeField]
    private GameObject turretBody;
    //canna di fuoco della torretta
    private GameObject bulletSpawnpoint;
    //tempo di ricarica torretta
    public float reloadTime;
    //booleano se la torretta è carica o meno
    public bool shootReady;

    public bool autoFire;
    //lista dei nemici
    public List<GameObject> enemies;
    private float blastPower;
    private Transform cannonStart;
    

    void Start()
    {
        bulletSpawnpoint = cannon.GetComponent<BNG.ProjectileLauncher>().MuzzleTransform.gameObject;
        blastPower = cannon.GetComponent<BNG.ProjectileLauncher>().ProjectileForce;
        cannonStart = cannon.transform;
    }
    private void OnEnable()
    {
        cannon.transform.position = cannonStart.position;
        cannon.transform.rotation = cannonStart.rotation;

    }
    // Update is called once per frame
    void Update()
    {
        if (autoFire && shootReady && enemies.Count > 0)
        {
            if (target != null) {
                turretBody.transform.LookAt(target.transform);
                Shoot();
            }else
            {
                enemies.RemoveAt(0);
                CheckForTarget();
            }  
        }
    }
    void Shoot()
    {
        shootReady = false;
        instanceBullet = Instantiate(bullet.transform, bulletSpawnpoint.transform.position, bulletSpawnpoint.transform.rotation);
        instanceBullet.GetComponent<FollowTarget>().target = target;
        instanceBullet.GetComponent<Rigidbody>().AddForce(bulletSpawnpoint.transform.forward * blastPower, ForceMode.VelocityChange);
        Invoke("FireRate", reloadTime);
    }
    void FireRate()
    {
        shootReady = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            CheckForTarget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
            CheckForTarget();
        }
    }
    private void CheckForTarget()
    {
        if (enemies.Count > 0)
        {
            target = enemies[0];
        }
        else
        {
            target = null;
        }
    }
    public void AutoFireTrue() {
        autoFire = true;
    }
    public void AutoFireFalse() {
        autoFire = false;
    }
}