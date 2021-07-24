using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Firegame : MonoBehaviour
{
    public int cooldownfire = 10;
    public int minigametime = 5;
    public GameObject[] firebuttons;
    public int fireboost = 0;
    public GameObject firecomponent;
    private bool fire;
    private Button thisButton;

     public void Start()
    {
        thisButton = GetComponent<Button>();
    }
    //gestisce la comparsa del minigioco e della ui del buff
     public void Update()
    {
        
            
        if (fire)
        {
            GetComponent<Image>().enabled = false;
            thisButton.enabled = false;
            firecomponent.SetActive(true);
        }

        if(!fire)
        {
            GetComponent<Image>().enabled = true;
            thisButton.enabled = true;
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
        yield return new WaitForSeconds(minigametime);
        Fireboostlenght();
        fire = false;
        thisButton.interactable = false;

        StartCoroutine(Buttoncooldown());
    }

    IEnumerator Buttoncooldown()
    {
        yield return new WaitForSeconds(cooldownfire + minigametime);
        thisButton.interactable = true;
    }

    
    //controlla quanto lungo sara' il buff assegnato
    public void Fireboostlenght()
    {
        if (fireboost >= 6 && fireboost < 12)
            
            Debug.Log(" hai 5 secondi");
        if (fireboost >=12 && fireboost < 18)
            
        Debug.Log(" hai 10 secondi");
        if (fireboost >= 18)
            
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
