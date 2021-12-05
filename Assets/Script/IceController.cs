using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceController : MonoBehaviour
{
    
    public GameObject c, cb, c1, cb1, c2, cb2, c3, cb3, c4, cb4, c5, cb5;
    public GameObject script;
    
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (script.GetComponent<IceGame2>().iceBoost >6)
        {
            c.SetActive(false);
        }
        if (script.GetComponent<IceGame2>().iceBoost > 12)
        {
            cb.SetActive(false);
        }

        if (script.GetComponent<IceGame2>().iceBoost > 18)
        {
            c1.SetActive(false);
        }
        if (script.GetComponent<IceGame2>().iceBoost > 24)
        {
            cb1.SetActive(false);
        }

        if (script.GetComponent<IceGame2>().iceBoost > 30)
        {
            c2.SetActive(false);
        }
        if (script.GetComponent<IceGame2>().iceBoost > 36)
        {
            cb2.SetActive(false);
        }

        if (script.GetComponent<IceGame2>().iceBoost > 42)
        {
            c3.SetActive(false);
        }
        if (script.GetComponent<IceGame2>().iceBoost > 48)
        {
            cb3.SetActive(false);
        }

        if (script.GetComponent<IceGame2>().iceBoost > 50)
        {
            c4.SetActive(false);
        }
        if (script.GetComponent<IceGame2>().iceBoost > 55)
        {
            cb4.SetActive(false);
        }

        if (script.GetComponent<IceGame2>().iceBoost > 59)
        {
            c5.SetActive(false);
        }
        if (script.GetComponent<IceGame2>().iceBoost > 61)
        {
            cb5.SetActive(false);
        }

        if (script.GetComponent<IceGame2>().iceBoost == 0)
        {
            c.SetActive(true);
            cb.SetActive(true);
            c1.SetActive(true);
            cb1.SetActive(true);
            c2.SetActive(true);
            cb2.SetActive(true);
            c3.SetActive(true);
            cb3.SetActive(true);
            c4.SetActive(true);
            cb4.SetActive(true);
            c5.SetActive(true);
            cb5.SetActive(true);
        }
    }

    public void Iced()
    {
         script.GetComponent<IceGame2>().iceBoost += 1;

    }
    
}
