using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner1 : MonoBehaviour
{
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject blueButton;
    public GameObject spawnPoint;
    public bool clicked;
    //public float x = 0;
    //public float y = 0;
    //public float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clicked)
        {
            redButton.SetActive(true);
            greenButton.SetActive(true);
            blueButton.SetActive(true);

        }
        if(!clicked)
        {
            redButton.SetActive(false);
            greenButton.SetActive(false);
            blueButton.SetActive(false);
        }

    }

    public void SpawnTowerButtons()
    {

        clicked = !clicked;
        
        
        
    }
}
