using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    //0 = blue, 1 = copper, 2 = gold, 3 = green, 4 = red 
    public int gemType;
    public void Start() {

    }
    public void OnCollisionEnter(Collision coll) {

        if (coll.gameObject.CompareTag("Player")) {
            GameEvents.singleton.GemCollected(gemType);

            Destroy(gameObject);
        }
        
    }

}
