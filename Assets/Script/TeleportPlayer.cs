using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject particles;
    public bool succedequalcosa;
    public GameObject tpointUnderground;
    public GameObject questo;
    // Start is called before the first frame update
    void Start()
    {
        succedequalcosa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (succedequalcosa)
            StartCoroutine(TeleportPoint());
           
        if (Input.GetKeyDown(KeyCode.A))
            succedequalcosa = true;
    }

    

    IEnumerator TeleportPoint()
    {
        succedequalcosa = false;
        particles.SetActive(true);
        yield return new WaitForSeconds(3);
        gameObject.transform.position = new Vector3(tpointUnderground.transform.position.x,
            tpointUnderground.transform.position.y, tpointUnderground.transform.position.z);
        
        particles.SetActive(false);

    }
}
