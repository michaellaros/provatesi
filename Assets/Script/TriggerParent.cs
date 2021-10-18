using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParent : MonoBehaviour
{
    public GameObject[] enableOnTrigger;
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
        }
    }
    public void DisableList()
    {
        foreach (GameObject obj in enableOnTrigger)
        {
            obj.SetActive(false);
        }
    }
    public void EnableList()
    {
        foreach (GameObject obj in enableOnTrigger)
        {
            obj.SetActive(true);
        }
    }
}
