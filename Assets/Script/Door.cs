using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float health;
    public Transform DoorLeft;
    public Transform DoorRight;

    public void TakeDamage(float dmg) {
        health = health - dmg;
        if (health < 0) {
            Open();
            return;
        }
        StartCoroutine("PulseLeft");
    }
    private void Open() {
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine("ShutOpen");
    }
    IEnumerator Pulse() {
        while (DoorLeft.position.z >= -0.2f) {
            DoorLeft.position = new Vector3(0,0,(DoorLeft.position.z-0.03f));
            DoorRight.position = new Vector3(0,0,(DoorRight.position.z-0.03f));
            new WaitForSeconds(0.1f);
        }
        while (DoorLeft.position.z >= 0)
        {
            DoorLeft.position = new Vector3(0, 0, (DoorLeft.position.z + 0.03f));
            DoorRight.position = new Vector3(0, 0, (DoorRight.position.z + 0.03f));
            new WaitForSeconds(0.1f);
        }
        return null;
    }
    IEnumerator ShutOpen()
    {
        while (DoorLeft.rotation.y >= -90f)
        {
            DoorLeft.transform.Rotate(0, -10, 0);
            DoorRight.transform.Rotate(0, 10, 0);
            new WaitForSeconds(0.1f);
        }
        return null;
    }
}