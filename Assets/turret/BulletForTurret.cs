using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForTurret : MonoBehaviour
{
    public float movementSpeed;
    private GameObject target;
    public int damage;    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = other.gameObject;
            target.GetComponent<Enemyscript>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
