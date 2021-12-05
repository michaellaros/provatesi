using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyMe");   
    }
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
