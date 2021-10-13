using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float health;
    private bool dead;
    public Transform DoorLeft;
    public Transform DoorRight;

    public void Start()
    {
        dead = false;
    }
    public void TakeDamage(float dmg) {
        health = health - dmg;
        if (health <= 0 && !dead) {
            dead = true;
            Open();
            return;
        }
    }
    private void Open() {
        GetComponent<BoxCollider>().isTrigger = false;
        DoorLeft.transform.Rotate(0, -90, 0);
        DoorRight.transform.Rotate(0, 90, 0);
        Invoke("DisableCollider", 0.1f);
    }
    private void DisableCollider() {
        GetComponent<BoxCollider>().enabled = false;
    }

}