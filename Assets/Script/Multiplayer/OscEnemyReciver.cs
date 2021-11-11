using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscEnemyReciver : MonoBehaviour
{
    public OSC myOsc;
    public List<Enemy> enemies;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        myOsc.SetAddressHandler("/EnemyValue", ValueUpdate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ValueUpdate(OscMessage message) {
        //TODO inserire fattore ID
        enemy.localPosition = new Vector3(message.GetFloat(1), message.GetFloat(2), message.GetFloat(3));
        enemy.localRotation = new Quaternion(message.GetFloat(4), message.GetFloat(5), message.GetFloat(6), message.GetFloat(7)); 

    }
}
