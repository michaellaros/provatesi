using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager singleton;
    public int blueGem;
    public int copperGem;
    public int goldGem;
    public int greenGem;
    public int redGem;
     
    // Start is called before the first frame update
    void Awake()
    {
        singleton = this;
    }

    public void Start() {
        GameEvents.singleton.onGemCollected += GemCollected;
    }

    private void GemCollected(int gemType)
    {
        //colleziona le gemme come thanos
        switch (gemType)
        {
            case 0:
                blueGem += 1;
                break;
            case 1:
                copperGem += 1;
                break;
            case 2:
                goldGem += 1;
                break;
            case 3:
                greenGem += 1;
                break;
            case 4:
                redGem += 1;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
