using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public TextMeshProUGUI RoomName;
    CreateAndJoinRooms manager;

    private void Start()
    {
        manager = FindObjectOfType<CreateAndJoinRooms>();
    }
    public void SetRoomName(string _roomName)
    {
        RoomName.text = _roomName ;
    }

    public void OnclickItem()
    {
        manager.JoinRoom(RoomName.text);
    }

    





}

