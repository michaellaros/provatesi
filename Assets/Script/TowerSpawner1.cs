using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner1 : MonoBehaviour
{
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject spawnPoint;
    public bool spawned;
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
        if (spawned)
        {
            GetComponent<Image>().color = Color.red;
            GetComponent<Button>().interactable = false;
        }
        if (!spawned)
        {
            GetComponent<Image>().color = Color.white;
            GetComponent<Button>().interactable = true;
        }

    }

    public void SpawnTower()
    {

        //Vector3 spawnPos = new Vector3(x, y, z);
        spawned = true;
        Instantiate(tower1, spawnPoint.transform.position, Quaternion.identity);
        
    }
}
