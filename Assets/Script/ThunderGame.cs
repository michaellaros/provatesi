using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThunderGame : MonoBehaviour
{
    public GameObject buttonManager;
    private float spawnLimitXLeft = -891;
    private float spawnLimitXRight = 950;
    private float spawnPosY = 630;
    private bool startSpawn;
    public GameObject[] thunderPrefabs;
    public Transform parent;
    public List<GameObject> allTHunder;
    private bool thunder;
    public GameObject thunderComponent;
    private Button thisButton;
    public int thunderBoost;
    public int cooldownThunder = 10;
    public int minigametime = 5;
    private GameObject tesla;
    private GameObject thunderZap;
    

    // Start is called before the first frame update
    void Start()
    { 
        thunder = false;
        thisButton = GetComponent<Button>();
    }
    // Update is called once per frame
    void Update()
    {
        if (thunder)
        {
            GetComponent<Image>().enabled = false;
            thisButton.enabled = false;
        }
        if (!thunder)
        {
            GetComponent<Image>().enabled = true;
            thisButton.enabled = true;
        }
    } 
    void SpawnThunder()
    {
        // Generate random ball index and random spawn position
        if (thunder == true)
        {
            float x = Random.Range(-883, 941);
            Vector2 spawnPos = new Vector2 (x, 600);

            int thunderindex = Random.Range(0, thunderPrefabs.Length);
            // instantiate ball at random spawn location
            thunderZap = Instantiate(thunderPrefabs[thunderindex], spawnPos, thunderPrefabs[0].transform.rotation);
            thunderZap.transform.SetParent(parent, false);
            allTHunder.Add(thunderZap);
        }

    }
    public void Thunderpower()
    {
        buttonManager.GetComponent<buttonManager>().Manager = true;
        thunder = true;
        StartCoroutine(Thunderreset());
        startSpawn = true;
        tesla = Instantiate(thunderComponent, thunderComponent.transform.position, thunderComponent.transform.rotation);
        tesla.transform.SetParent(parent, false);
        if (startSpawn == true && thunder == true)
        InvokeRepeating(nameof(SpawnThunder), 1f, 0.5f);
        startSpawn = false;


    }

    IEnumerator Thunderreset()
    {
        yield return new WaitForSeconds(20);
        Thunderboostlenght();
        buttonManager.GetComponent<buttonManager>().Manager = false;
        thunder = false;
        thisButton.interactable = false;
        
        Destroy(tesla);
        
        foreach (var item in allTHunder)
        {
            if(item != null)
            {
                Destroy(item);
            }
        }
       
        StartCoroutine(Buttoncooldown());
    }

    IEnumerator Buttoncooldown()
    {
        yield return new WaitForSeconds(5);
        thisButton.interactable = true;
    }

    public void Thunderboostlenght()
    {
        thunderBoost = tesla.GetComponent<Tesla_behaviour>().boost;

        if (thunderBoost < 10 && thunderBoost < 20)

            Debug.Log(" hai 5 secondi");
        if (thunderBoost >= 20 && thunderBoost < 37)

            Debug.Log(" hai 10 secondi");
        if (thunderBoost >= 37)

            Debug.Log(" hai 15 secondi");

        thunderBoost = 0;
    }
}
