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
    [SerializeField]public List<GameObject> enemies;


    private void Start()
    {
        shootReady = true;
    }
    void Update()
    {
        if (targetlocked)
        {
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
                enemies.RemoveAt(0);
            }
            

        }
    }

        private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            target = enemies[0];
            targetlocked = true;
            if (targetlocked)
                Debug.Log("colpito");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            int index = enemies.IndexOf(other.gameObject);
            enemies.RemoveAt(index);
            targetlocked = false;
            if (targetlocked)
                Debug.Log("colpito");
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
}








































    //// Start is called before the first frame update
    //void Start()
    //{
    //    shootReady = true;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (targetlocked)
    //    {
    //        turretTopPart.transform.LookAt(target.transform);
    //        turretTopPart.transform.Rotate(0, -90, 0);
    //        if (shootReady)
    //        {
    //            Shoot();
    //        }

    //    }
    //}
    

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag =="Enemy")
    //    {
    //        target = other.gameObject;
    //        targetlocked = true;
    //        if (targetlocked)
    //            Debug.Log("colpito");
    //    }
    //    if (other.tag == "IdlePoint")
    //    {
    //        target = other.gameObject;
    //        targetlocked = false;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Enemy")
    //    {
    //        target = other.gameObject;
    //        targetlocked = true;


    //    }
    //}

