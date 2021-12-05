using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFreeze : MonoBehaviour
{
    public bool toDetonate;
    Rigidbody rb;
    public bool primoImpatto;
    public float destroyTime;
    public GameObject particle;
    public float mineDamage;
    public float blastRadius = 20f;
    public float explosionForce = 10f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        primoImpatto = true;
        toDetonate = true;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particle, transform.position, transform.rotation);

            //Explosion();
            
            toDetonate = false;
            Destroy(gameObject);
            //StartCoroutine("DestroyMe");
        }
        if (collision.gameObject.CompareTag("Mine"))
        {
            Instantiate(particle, transform.position, transform.rotation);
            if (toDetonate)
            {

                //Explosion();
                toDetonate = false;
                //StartCoroutine("DestroyMe");
                Destroy(gameObject);

            }
            
        }
        if (primoImpatto)
        {
            StartCoroutine("Placing");
        }
    }

    //void Explosion()
    //{
        
    //    Collider[] enemiesInArea = Physics.OverlapSphere(transform.position, blastRadius);
    //    foreach (Collider nearbyObject in enemiesInArea)
    //    {
    //        if (nearbyObject.CompareTag("Enemy"))
    //        {
    //            Enemy currentEnemy = nearbyObject.gameObject.GetComponent<Enemy>();
    //            currentEnemy.TakeDamage(mineDamage);
    //            currentEnemy.TakeExplosion(explosionForce, transform.position, blastRadius);
    //            rb.AddExplosionForce(explosionForce, explosionCenter, explosionRadius);
    //        }
            
    //    }

        //Collider[] enemiesToMove = Physics.OverlapSphere(transform.position, blastRadius);
        //foreach (Collider nearbyObject in enemiesToMove)
        //{
        //    if (nearbyObject.CompareTag("Enemy"))
        //    {
        //        Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

        //        if (rb != null)
        //        {
        //            rb.AddExplosionForce(explosionForce, transform.position, blastRadius,3.0f);
        //        }
        //    }
        //}
    //}
    //IEnumerator DestroyMe()
    //{
    //    yield return new WaitForSeconds(destroyTime);
    //    Destroy(this.gameObject);
    //}
    IEnumerator Placing()
    {
        primoImpatto = false;
        yield return new WaitForSeconds(3);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
