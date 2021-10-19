using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
   
    public GameObject spawnPoint;
    public bool spawned;
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.parent.GetComponent<TowerSpawner1>().spawnPoint;
    }

    // Update is called once per frame
    

    public void ButtonController()
    {
        spawned = true;
        Instantiate(tower, spawnPoint.transform.position, Quaternion.identity);
        GameEvents.singleton.SpawnTower();
        CheckForSpawn();
    }
    public void CheckForSpawn()
    {
        if (spawned)
        {

            GetComponent<Button>().interactable = false;
        }
        if (!spawned)
        {

            GetComponent<Button>().interactable = true;
        }
    }
}
