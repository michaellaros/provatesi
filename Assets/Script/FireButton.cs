using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableMe()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
    }
    public void EnableMe() {
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
    }
}
