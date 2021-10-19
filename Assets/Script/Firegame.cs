using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Firegame : MonoBehaviour
{
    public GameObject buttonManager;
    public int cooldownfire = 10;
    public int minigametime = 5;
    public GameObject[] firebuttons;
    public int fireboost = 0;
    public GameObject firecomponent;
    private bool fire;
    private Button thisButton;
    public float buff = 5;
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
        buttonManager.GetComponent<buttonManager>().Manager = true;
        fire = true;
        StartCoroutine(Firereset());
        
    }

    IEnumerator Firereset()
    {
        yield return new WaitForSeconds(minigametime);
        Fireboostlenght();
        buttonManager.GetComponent<buttonManager>().Manager = false;
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
        {
            GameEvents.singleton.FireBoost(buff);
            Debug.Log(" hai 5 secondi");
        }
        if (fireboost >=12 && fireboost < 18)
        {
            GameEvents.singleton.FireBoost(buff * 2);
            Debug.Log(" hai 10 secondi");
        }
        if (fireboost >= 18)
        {
            GameEvents.singleton.FireBoost(buff * 3);
            Debug.Log(" hai 15 secondi");
        }

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
