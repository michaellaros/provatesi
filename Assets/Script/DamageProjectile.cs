using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProjectile : MonoBehaviour
{
    public float damage;
    public float destroyTime;
    private CheckElement sourceDamage;
    public int damagetype;
    public void Start()
    {
        
        
        

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().TakeDamage(damage, damagetype);
            StartCoroutine("DestroyMe");

        }
    }
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
