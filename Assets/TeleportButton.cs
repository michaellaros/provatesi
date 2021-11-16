using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportButton : MonoBehaviour
{
    public Text text;
    bool ritirata;
    public float coolDown;

    // Start is called before the first frame update
    void Start()
    {
        ritirata = false;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (ritirata)
        {
            text.GetComponent<Text>().text = "Attacco!";
            GetComponent<Image>().color = Color.red;
            coolDown = 5f;
        }
        else
        {
            text.GetComponent<Text>().text = "Ritirata!";
            GetComponent<Image>().color = Color.green;
            coolDown = 7f;
        }
    }

    public void Teleport()
    {
        ritirata = !ritirata;
        
        GetComponent<Button>().interactable = false;
        StartCoroutine(CoolDown());
        // codice tp playerVR
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDown);
        GetComponent<Button>().interactable = true;

    }
}
