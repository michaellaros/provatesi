using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    private GameObject target;
    private bool targetlocked;
    public GameObject turretTopPart;
    public float fireTimer;
    private bool shootReady;
    public GameObject bulletSpawnpoint;


    // Start is called before the first frame update
    void Start()
    {
        shootReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetlocked)
        {
            turretTopPart.transform.LookAt(target.transform);
            turretTopPart.transform.Rotate(0, -90, 0);
            if (shootReady)
            {
                Shoot();
            }
            
        }
    }
    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnpoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnpoint.transform.rotation;
        shootReady = false;
        StartCoroutine(FireRate());

    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shootReady = true;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {
            target = other.gameObject;
            targetlocked = true;
            if (targetlocked)
                Debug.Log("colpito");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = other.gameObject;
            targetlocked = true;
            
                
        }
    }
}
