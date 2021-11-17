using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListingElement _roomListing;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList) {
            RoomListingElement listing = Instantiate(_roomListing, _content);
            if (listing != null) {
                listing.SetRoomInfo(info);
            }
        }
    }

}
