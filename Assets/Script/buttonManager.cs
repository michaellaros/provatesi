using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonManager : MonoBehaviour
{
    public GameObject fire;
    public GameObject ice;
    public GameObject thunder;
    public bool Manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager)
        {
            ice.GetComponent<Button>().interactable = false;
            thunder.GetComponent<Button>().interactable = false;
            fire.GetComponent<Button>().interactable = false;
        }
        if (!Manager)
        {
            ice.GetComponent<Button>().interactable = true;
            thunder.GetComponent<Button>().interactable = true;
            fire.GetComponent<Button>().interactable = true;
        }


    }
}
