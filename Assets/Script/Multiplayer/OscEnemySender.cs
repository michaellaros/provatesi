using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscEnemySender : MonoBehaviour
{
    public OSC myOsc;
    private OscMessage messageToSend;
    private Enemy me;
    // Start is called before the first frame update
    void Start()
    {
        myOsc = GameObject.FindGameObjectWithTag("OSC").GetComponent<OSC>();
        me = GetComponent<Enemy>();
    }
    private void SendTransform() {
        messageToSend = new OscMessage();
        messageToSend.address = "/EnemyValue";
        messageToSend.values.Add(me.id);
        messageToSend.values.Add(me.getHealth());
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
    public void deathMessage()
    {
        messageToSend = new OscMessage();
        messageToSend.address = "/EnemyDeath";
        messageToSend.values.Add(me.id);
    }
}