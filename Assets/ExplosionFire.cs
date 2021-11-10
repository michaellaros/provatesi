using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFire : MonoBehaviour
{
    public List<GameObject> fire;
    public float push;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnForce = new Vector3(Random.Range(-push, push),0, Random.Range(-push, push));
        foreach (GameObject fires in fire)
        {
            fires.GetComponent<Rigidbody>().AddForce(spawnForce, ForceMode.Impulse);
        }
        StartCoroutine(DestroyThat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyThat()
    {
        yield return new WaitForSeconds(10);
        foreach (GameObject fires in fire)
        {
            Destroy(fires);
        }
    }
}
