using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject playerWarrior;
    public GameObject playerMage;
    public GameObject osc;
    public UnityEvent listenerGem;
    // Start is called before the first frame update
    void Start()
    {
        listenerGem.AddListener(CollectRedGem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectRedGem() {
        //colleziona la redgem
    }

}
