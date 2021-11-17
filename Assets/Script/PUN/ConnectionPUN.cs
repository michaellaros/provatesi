using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPUN : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connetting");
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public override void OnConnectedToMaster()
    {
        print("Connected");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected why: " + cause.ToString());
    }
}
