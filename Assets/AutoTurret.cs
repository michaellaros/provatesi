using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    //proiettile
    [SerializeField]
    private GameObject bullet;
    //obiettivo da sparare, se null, la torretta non spara
    private GameObject target;
    
    [SerializeField]
    private GameObject turretBody;
    //parte superiore della torretta
    [SerializeField]
    private GameObject turretMuzzle;
    //tempo di ricarica torretta
    public float reloadTime;
    //booleano se la torretta è carica o meno
    public bool shootReady;
    //canna di fuoco della torretta
    public GameObject bulletSpawnpoint;
    //lista dei nemici
    public List<GameObject> enemies;
    public GameObject projectileLauncherOBJ;
    public bool autoFire;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
