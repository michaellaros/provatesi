using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text _roomName;

    public void OnClick_CreateRoom() {
        if (!PhotonNetwork.IsConnected)
            return;
        if (!(_roomName.text == ""))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 2;
            PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
        }
    }

    public override void OnCreatedRoom() {
        Debug.Log("created room");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("creation room fail: "+message, this);
    }
}
