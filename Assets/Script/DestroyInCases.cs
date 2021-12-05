using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInCases : MonoBehaviour
{
    public bool DestroyWithTime;
    public float DestroyTime;
    public GameObject possessiveFather;
    public float DestroyDistanceFromFather;
    // Start is called before the first frame update
    void Start()
    {
        if (DestroyWithTime) {
            StartCoroutine("DestroyTimer");
        }
        if (possessiveFather != null) {
            StartCoroutine("DestroyIfTooFar");
        }
    }

    // Update is called once per frame
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
    IEnumerator DestroyIfTooFar()
    {
        while (DestroyDistanceFromFather > Vector3.Distance(transform.position, possessiveFather.transform.position))
        {
            yield return new WaitForSeconds(0.5f);
        }
        DestroyMe();
    }
    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(DestroyTime);
        DestroyMe();
    }

}
