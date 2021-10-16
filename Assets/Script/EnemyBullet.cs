using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float movementSpeed;
    public GameObject target;
    public float damage;

    public void Start()
    {
        gameObject.transform.LookAt(target.transform);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Enemyscript>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

}