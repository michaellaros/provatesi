using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.transform.parent.parent.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider collider) {
        if (collider.CompareTag("Player"))
        {
            collider.transform.parent.parent.SetParent(null);
        }
    }
}
