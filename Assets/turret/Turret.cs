using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //proiettile
    [SerializeField]
    private GameObject bullet;
    //obiettivo da sparare, se null, la torretta non spara
    private GameObject target;
    //parte superiore della torretta
    [SerializeField]
    private GameObject turretTopPart;
    //tempo di ricarica torretta
    [SerializeField]
    private float reloadTime;
    //booleano se la torretta è carica o meno
    private bool shootReady;
    //canna di fuoco della torretta
    public GameObject bulletSpawnpoint;
    //lista dei nemici
    public List<GameObject> enemies;


    private void Start()
    {
        shootReady = true;
    }
    void FixedUpdate()
    {
        if (enemies.Count > 0)
        {
            TryToShoot();
        }
    }
    public void TryToShoot() {
        try
        {
            turretTopPart.transform.LookAt(target.transform);
            turretTopPart.transform.Rotate(0, -90, 0);
            if (shootReady)
            {
                Shoot();
            }
        }
        catch
        {
            if (enemies.Count > 0)
            {
                enemies.RemoveAt(0);
            }
            CheckForTarget();
        }
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
        else {
            target = null;
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnpoint.transform.position, Quaternion.identity);
        _bullet.GetComponent<BulletForTurret>().target = target;
        _bullet.transform.rotation = bulletSpawnpoint.transform.rotation;
        shootReady = false;
        Invoke("FireRate", reloadTime);
    }

    void FireRate()
    {
        shootReady = true;
    }
}