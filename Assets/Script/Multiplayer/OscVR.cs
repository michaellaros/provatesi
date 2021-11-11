using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscVR : MonoBehaviour
{
    public OSC myOsc;
    private OscMessage messageToSend;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SendTransform();
        
    }

    private void SendTransform() {
        messageToSend = new OscMessage();
        messageToSend.address = "/EnemyTransform";
        messageToSend.values.Add(0);
        AddTranformToMessage(transform);
        myOsc.Send(messageToSend);
    }
    private void AddTranformToMessage(Transform t)
    {
        //add position
        messageToSend.values.Add(t.localPosition.x);
        messageToSend.values.Add(t.localPosition.y);
        messageToSend.values.Add(t.localPosition.z);
        //add rotation
        messageToSend.values.Add(t.localRotation.x);
        messageToSend.values.Add(t.localRotation.y);
        messageToSend.values.Add(t.localRotation.z);
        messageToSend.values.Add(t.localRotation.w);
    }

}
