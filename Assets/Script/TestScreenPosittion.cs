using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class TestScreenPosittion : MonoBehaviour
{
    public CanvasScaler UiCanvasScaler;
    public Vector2 ScreenMaxPositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 GetScreenMaxPositions()
    {
        Vector2 originalScreenResolution = new Vector2(Screen.width, Screen.height);
        float screenMaxHeight = (originalScreenResolution.y / originalScreenResolution.x) * UiCanvasScaler.referenceResolution.x;
        ScreenMaxPositions = new Vector2(UiCanvasScaler.referenceResolution.x, screenMaxHeight);
        return ScreenMaxPositions;
    }


}
