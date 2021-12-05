using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public float health;
    private bool dead;
    public GameObject[] archers;
    public int eliminated;

    public void Start()
    {
        dead = false;
        eliminated = 0;
    }

    
    public void TakeDamage(float dmg)
    {
        
        health = health - dmg;
        
        if (health <= 0 && !dead)
        {
            dead = true;
            CallGameOver();
        }

        if (health % 10 == 0 && eliminated < archers.Length)
        {
            Destroy(archers[eliminated]);
            GameEvents.singleton.CharacterDisappear(eliminated);
            eliminated += 1;
            
        }
        
        
    }
    
    private void CallGameOver()
    {
        Time.timeScale = 0;
        print("game over");
        
    }

}