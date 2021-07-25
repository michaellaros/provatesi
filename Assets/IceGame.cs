﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceGame : MonoBehaviour
{
    private bool ice;
    public GameObject iceComponent;
    private Button thisButton;
    public int iceBoost = 0;
    public int cooldownfire = 10;
    public int minigametime = 5;

    // Start is called before the first frame update
    void Start()
    {
        ice = false;
        thisButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ice)
        {
            GetComponent<Image>().enabled = false;
            thisButton.enabled = false;
            iceComponent.SetActive(true);
        }

        if (!ice)
        {
            GetComponent<Image>().enabled = true;
            thisButton.enabled = true;
            iceComponent.SetActive(false);

        }
    }

    public void Icepower()
    {
        ice = true;
        StartCoroutine(Icereset());

    }

    IEnumerator Icereset()
    {
        yield return new WaitForSeconds(5);
        Iceboostlenght();
        ice = false;
        thisButton.interactable = false;

        StartCoroutine(Buttoncooldown());
    }

    IEnumerator Buttoncooldown()
    {
        yield return new WaitForSeconds(cooldownfire + minigametime);
        thisButton.interactable = true;
    }

    public void Iceboostlenght()
    {
        if (iceBoost >= 6 && iceBoost < 12)

            Debug.Log(" hai 5 secondi");
        if (iceBoost >= 12 && iceBoost < 18)

            Debug.Log(" hai 10 secondi");
        if (iceBoost >= 18)

            Debug.Log(" hai 15 secondi");

        iceBoost = 0;
    }
}
