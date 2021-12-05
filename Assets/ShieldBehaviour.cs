using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public GameObject arrow;
    public GameObject hitShieldAudio;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Arrow"))
        {
            Instantiate(hitShieldAudio, enemy.transform.position, enemy.transform.rotation);
            arrow.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyAudio());
        }
    }

    IEnumerator DestroyAudio()
    {
        yield return new WaitForSeconds(3);
        Destroy(arrow);
    }
}
