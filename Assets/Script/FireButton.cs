using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    Vector2 pos;

    // Start is called before the first frame update
    

    // Update is called once per frame
    
    public void DisableMe()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
    }
    public void EnableMe() 
    {
        float x = Random.Range(10f,Screen.width);
        float y = Random.Range(10f, Screen.height);
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
        pos = new Vector2(x, y);
        GetComponent<Transform>().position = pos;
    }
}
