using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceGameFloor : MonoBehaviour
{
    public GameObject game;
    public GameObject iceCube;
    public float speedmultiplier = 20;
    public float rotateSpeed = 5000000;
    private RectTransform rectTransform;
    public bool ice2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {


        if (ice2)
        {
            iceCube.transform.SetParent(this.transform);
        }
        else
        {
            iceCube.transform.SetParent(game.transform);
        }
        

        if (ice2 && Input.GetMouseButton(0))
        {
            rectTransform.Rotate(0, 0, speedmultiplier * rotateSpeed * Time.deltaTime);
            Debug.Log("sto ruotando");
        }
        if (ice2 && Input.GetMouseButton(1))
        {
            rectTransform.Rotate(0, 0, speedmultiplier * -rotateSpeed * Time.deltaTime);
            Debug.Log("sto ruotando2");
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "IceCube")
        {

            ice2 = true;
        }
        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "IceCube")
        {

            ice2 = false;
        }

    }
}
