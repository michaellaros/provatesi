using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_behaviour : MonoBehaviour
{
    
    public int boost;
    public float waitTime = 0.5f;
    RectTransform myrecttransform;
    

    public void Start()
    {
        myrecttransform = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            myrecttransform.anchoredPosition = Input.mousePosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thunder"))
        {
            
            //StartCoroutine(Hitfalse());
            boost += 1;
            Destroy(collision.gameObject);
        }
    }

    
}
