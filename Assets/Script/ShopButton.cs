using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public InventoryManager inventorymanager;
    public GameObject spawnPoint;
    public bool spawned;
    public List <GameObject> tower;
    private ShopButton redB;
    private ShopButton greenB;
    private ShopButton blueB;
    private Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.singleton.onGemCollected += GemCollected;
        GameObject parentButton = transform.parent.gameObject;
        redB = parentButton.transform.GetChild(0).GetComponent<ShopButton>();
        greenB = parentButton.transform.GetChild(1).GetComponent<ShopButton>();
        blueB = parentButton.transform.GetChild(2).GetComponent<ShopButton>();
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        GameEvents.singleton.onGemCollected -= GemCollected;
    }

    public void GemCollected(int gemType)
    {
        if (!spawned)
        {
            if (inventorymanager.copperGem >= 5)
            {
                myButton.interactable = true;
            }
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            if (inventorymanager.copperGem >= 5)
            {
                myButton.interactable = true;
            }
        }

    }
    public void OnClick() {
        if (transform.name == "Red") 
        {
            REDButtonController();
        }
        if (transform.name == "Blue")
        {
            BLUEButtonController();
        }
        if (transform.name == "Green")
        {
            GREENButtonController();
        }
    }
    public void SpawnedTrue()
    {
        spawned = true;
        myButton.interactable = false;
    }

    public void REDButtonController()
    {
        redB.SpawnedTrue();
        greenB.SpawnedTrue();
        blueB.SpawnedTrue();
        Instantiate(tower[0], spawnPoint.transform.position, Quaternion.identity);
        GameEvents.singleton.SpawnTower();
        
    }



    public void GREENButtonController()
    {
        redB.SpawnedTrue();
        greenB.SpawnedTrue();
        blueB.SpawnedTrue();
        Instantiate(tower[1], spawnPoint.transform.position, Quaternion.identity);
        GameEvents.singleton.SpawnTower();
        
    }



    public void BLUEButtonController()
    {
        redB.SpawnedTrue();
        greenB.SpawnedTrue();
        blueB.SpawnedTrue();
        Instantiate(tower[2], spawnPoint.transform.position, Quaternion.identity);
        GameEvents.singleton.SpawnTower();
        
    }
}
