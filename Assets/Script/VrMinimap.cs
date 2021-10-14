using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrMinimap : MonoBehaviour
{
    public Image minimap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( (transform.rotation.y>70f) || (transform.rotation.y < -80f)){
            minimap.enabled = true;
        }
        else
        {
            minimap.enabled = false;
        }
    }
}
