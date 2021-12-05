using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButton : MonoBehaviour
{
    Vector3 pos;

    // Start is called before the first frame update
    
    
       
    
    // Update is called once per frame
    
    public void DisableMe()
    {
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().enabled = false;
    }
    public void EnableMe() 
    {
        
        float x = Random.Range(-811,954);
        float y = Random.Range(571, -444);
        GetComponent<Image>().enabled = true;
        GetComponent<Button>().enabled = true;
        pos = new Vector3(x, y, 0);
        
        GetComponent<RectTransform>().anchoredPosition = pos;
        Debug.Log(pos);
        Debug.Log(GetComponent<RectTransform>().anchoredPosition);
    }
}
