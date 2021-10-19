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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        primoImpatto = true;
        toDetonate = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Mine"))
        {
            if (toDetonate)
            {
                particle.SetActive(true);
                toDetonate = false;
                StartCoroutine("DestroyMe");
            }
        }
        if (primoImpatto)
        {
            StartCoroutine("Placing");
        }
    }
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
    IEnumerator Placing()
    {
        primoImpatto = false;
        yield return new WaitForSeconds(3);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
