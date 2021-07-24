using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Firegame : MonoBehaviour
{
    public int cooldownfire;
    public GameObject[] firebuttons;
    public int fireboost = 0;
    public GameObject firecomponent;
    private bool fire;
    
    
    //gestisce la comparsa del minigioco e della ui del buff
    private void Update()
    {
        if (cooldownfire >=1)
            
        if (fire)
        {
            GetComponent<Image>().enabled = false;
            GetComponent<Button>().enabled = false;
            firecomponent.SetActive(true);
        }

        if(!fire)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Button>().enabled = true;
            firecomponent.SetActive(false);
        }
    }
    

    //il minigioco e' attivo
    public void Firepower()
    {
        fire = true;
        StartCoroutine(Firereset());
        
    }

    IEnumerator Firereset()
    {
        yield return new WaitForSeconds(5);
        Fireboostlenght();
        fire = false;

        StartCoroutine(Buttoncooldown());
    }

    IEnumerator Buttoncooldown()
    {
        yield return new WaitForSeconds(cooldownfire);
        cooldownfire = 0;
    }

    
    //controlla quanto lungo sara' il buff assegnato
    public void Fireboostlenght()
    {
        if (fireboost >= 6 && fireboost < 12)
            cooldownfire = 5;
            Debug.Log(" hai 5 secondi");
        if (fireboost >=12 && fireboost < 18)
            cooldownfire = 10;
        Debug.Log(" hai 10 secondi");
        if (fireboost >= 18)
            cooldownfire = 15;
        Debug.Log(" hai 15 secondi");

        fireboost = 0;
    }
    //punteggio del minigioco per il buff e disattiva le fiamme in gioco
    public void Fireoff()
    {

        fireboost += 1;
        if(fireboost %6 == 0)
        {
             ReEnablefire();
        }
    }

    public void ReEnablefire()
    {
        foreach (var item in firebuttons)
        {
            item.GetComponent<FireButton>().EnableMe();
        }

        
    }
}
