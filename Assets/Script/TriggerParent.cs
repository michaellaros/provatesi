using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerParent : MonoBehaviour
{
    public GameObject[] enableOnTrigger;
    public GameObject[] disableOnTrigger;
    
    public event Action outOfTrigger;
    public void ExitTrigger() {
        if (outOfTrigger != null) {
            outOfTrigger();
        }
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.transform.parent.parent.SetParent(transform);
            EnableList();
            
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player"))
        {
            collider.transform.parent.parent.SetParent(null);
            DisableList();
            ExitTrigger();
        }
    }
    public void DisableList()
    {
        foreach (GameObject obj in enableOnTrigger)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in disableOnTrigger)
        {
            obj.SetActive(true);
        }
    }
    public void EnableList()
    {
        foreach (GameObject obj in enableOnTrigger)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in disableOnTrigger)
        {
            obj.SetActive(false);
        }
    }
}
