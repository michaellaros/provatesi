using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public float health;
    private bool dead;
    public Transform[] archers;

    public void Start()
    {
        dead = false;
    }
    public void TakeDamage(float dmg)
    {
        health = health - dmg;
        if (health <= 0 && !dead)
        {
            dead = true;
            CallGameOver();
        }
        //Inserire codice update UI vita Castello
    }
    private void CallGameOver()
    {
        print("game over");
        //TODO Gameover
    }

}