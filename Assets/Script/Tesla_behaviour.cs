using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_behaviour : MonoBehaviour
{

    public int boost;

    public void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Thunder"))
        {
            boost += 1;
            Destroy(collision.gameObject);
        }
    }
}
