using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFreeze : MonoBehaviour
{
    public bool freeze = false;
    public bool primoImpattoEX;
    Rigidbody rb;
    public bool primoImpatto;
    public float destroyTime;
    public GameObject particle;
    public float mineDamage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        primoImpatto = true;
        primoImpattoEX = true;
        print("sono nato");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mine"))
        {
            

            if (primoImpattoEX)
            {
                particle.SetActive(true);
                primoImpattoEX = false;
                StartCoroutine("DestroyMe");
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().TakeDamage(mineDamage);

            if (primoImpattoEX)
            {
                particle.SetActive(true);
                primoImpattoEX = false;
                StartCoroutine("DestroyMe");
            }
        }
        if (collision.gameObject)
        {
            //print("colpito");
            if(primoImpatto)
                StartCoroutine("Placing");
            if (freeze)
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        
    }
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
    IEnumerator Placing()
    {
        print("piazzato");
        primoImpatto = false;
        yield return new WaitForSeconds(3);
        freeze = true;
            StartCoroutine("DisablePlacing");
    }
    IEnumerator DisablePlacing()
    {
        yield return new WaitForSeconds(3);
        print("libero!");
        freeze = false;
        
    }
}
