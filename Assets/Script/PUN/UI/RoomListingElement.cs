
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListingElement : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    public void SetRoomInfo(Photon.Realtime.RoomInfo roomInfo) {
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
}
