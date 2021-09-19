using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceGame2 : MonoBehaviour
{
    public GameObject buttonManager;
    public bool ice;
    public GameObject iceComponent;
    private Button thisButton;
    public int iceBoost = 0;
    public int cooldownIce = 10;
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

        Debug.Log(iceBoost);
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
        buttonManager.GetComponent<buttonManager>().Manager = true;
        buttonManager.GetComponent<buttonManager>().Manager = false;
        ice = true;
        StartCoroutine(Icereset());

    }

    IEnumerator Icereset()
    {
        yield return new WaitForSeconds(10);
        Iceboostlenght();
        ice = false;
        buttonManager.GetComponent<buttonManager>().Manager = false;
        thisButton.interactable = false;

        StartCoroutine(Buttoncooldown());
    }

    IEnumerator Buttoncooldown()
    {
        yield return new WaitForSeconds(cooldownIce + minigametime);
        thisButton.interactable = true;
    }

    public void Iceboostlenght()
    {
        if (iceBoost >= 13 && iceBoost < 41)

            Debug.Log(" hai 5 secondi");
        if (iceBoost >= 41 && iceBoost < 61)

            Debug.Log(" hai 10 secondi");
        if (iceBoost >= 61)

            Debug.Log(" hai 15 secondi");

        iceBoost = 0;
    }
}
