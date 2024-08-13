using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public TextMeshProUGUI RoomName;

    public void SetRoomName(string _roomName)
    {
        RoomName.name = _roomName;
    }





}

