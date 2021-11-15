using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Trigger : MonoBehaviour
{
    public GameObject cameraMap;
    public bool mapOn;
    public GameObject map;
    // Start is called before the first frame update

    private void Start()
    {
        map.SetActive(false);
        cameraMap.SetActive(false);
    }
    void Update()
    {
        if (mapOn)
        {
            map.SetActive(true);
            cameraMap.SetActive(true);
        }


        if (!mapOn)
        {
            map.SetActive(false);
            cameraMap.SetActive(false);

        }
    }


        public void ToggleMap()
    {
        mapOn = !mapOn;

    }
    // Update is called once per frame

  
}
