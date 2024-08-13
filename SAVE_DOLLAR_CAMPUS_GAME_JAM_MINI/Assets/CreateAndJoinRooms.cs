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

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform PlayerItemParent;


    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        //PhotonNetwork.CreateRoom(CreateInput.text);
        if (CreateInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(CreateInput.text, new RoomOptions() { MaxPlayers = 4, BroadcastPropsChangeToAll = true});
        }
    }
    
   

    public override void OnJoinedRoom()
    {
        LobbyPanel.SetActive(false);
        RoomPanel.SetActive(true);
        RoomName.text = "ROOM NAME:" + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
       // PhotonNetwork.LoadLevel("LevelDesignTest");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;    

        }

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

    public void JoinRoom(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public void OnClickLeave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        LobbyPanel.SetActive(true);
        RoomPanel.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

    }

    private void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject );
        }

        playerItemsList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                PlayerItem newPlayerItem =  Instantiate(playerItemPrefab, PlayerItemParent);
                newPlayerItem.SetPlayerInfo(player.Value); 
            
                if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

                playerItemsList.Add(newPlayerItem);
            }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

}
