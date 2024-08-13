using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField CreateInput;

    public GameObject LobbyPanel;
    public GameObject RoomPanel;
    public TextMeshProUGUI RoomName;

    public RoomItem RoomItemPrefab;
    List <RoomItem> RoomItemList = new List <RoomItem> ();
    public Transform contentObject;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        //PhotonNetwork.CreateRoom(CreateInput.text);
        if (CreateInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(CreateInput.text, new RoomOptions() { MaxPlayers = 4});
        }
    }
    
   

    public override void OnJoinedRoom()
    {
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(true);
        RoomName.text = "ROOM NAME:" + PhotonNetwork.CurrentRoom.Name;
       // PhotonNetwork.LoadLevel("LevelDesignTest");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);

    }

    void UpdateRoomList(List<RoomInfo> List)
    {
        foreach (RoomItem item in RoomItemList)
        {
            Destroy(item.gameObject);
        }
        RoomItemList.Clear();

        foreach (RoomInfo room in List)
        {
            RoomItem newRoom =Instantiate(RoomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            RoomItemList.Add(newRoom);
        }
    }

}
