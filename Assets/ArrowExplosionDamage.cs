using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowExplosionDamage : MonoBehaviour
{
    public float damage;
    public float destroyTime;
    private CheckElement sourceDamage;
    public int damagetype;
    public void Start()
    {

        sourceDamage = GameObject.Find("XR Rig Advanced").GetComponent<CheckElement>();
        
        
        
            damagetype = 0;
            if (sourceDamage.fire)
            {
                damagetype = 1;
            }
            else if (sourceDamage.ice)
            {
                damagetype = 2;
            }
            else if (sourceDamage.thunder)
            {
                damagetype = 3;
            }
        

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

