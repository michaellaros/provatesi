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
    private void EnemyUpdateMessage() {
        messageToSend = new OscMessage();
        messageToSend.address = "/EnemyValue";
        messageToSend.values.Add(me.id);
        messageToSend.values.Add(me.getHealth());
        //add position
        messageToSend.values.Add(transform.localPosition.x);
        messageToSend.values.Add(transform.localPosition.y);
        messageToSend.values.Add(transform.localPosition.z);
        //add rotation
        messageToSend.values.Add(transform.localRotation.x);
        messageToSend.values.Add(transform.localRotation.y);
        messageToSend.values.Add(transform.localRotation.z);
        messageToSend.values.Add(transform.localRotation.w);
        //send message
        myOsc.Send(messageToSend);
    }
    public void DeathMessage()
    {
        messageToSend = new OscMessage();
        messageToSend.address = "/EnemyDeath";
        messageToSend.values.Add(me.id);
    }
}