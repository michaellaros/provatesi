using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceGame : MonoBehaviour
{
    
    public GameObject buttonManager;
    public bool ice;
    public GameObject iceComponent;
    private Button thisButton;
    public int iceBoost = 0;
    public int cooldownIce = 10;
    public int minigametime = 5;
    
    
    public GameObject floor;
    

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
        if (iceBoost >= 6 && iceBoost < 12)

            Debug.Log(" hai 5 secondi");
        if (iceBoost >= 12 && iceBoost < 18)

            Debug.Log(" hai 10 secondi");
        if (iceBoost >= 18)

            Debug.Log(" hai 15 secondi");

        iceBoost = 0;
    }
}
