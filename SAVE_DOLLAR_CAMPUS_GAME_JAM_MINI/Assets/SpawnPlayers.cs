using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject Player1;
    public GameObject Player2;

    public Transform Player1Pos;
    public Transform Player2Pos;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (PhotonNetwork.IsConnected)
        {
            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

            if (playerCount == 1)
            {
                PhotonNetwork.Instantiate(Player1.name, Player1Pos.position, Quaternion.identity);
            }
            if (playerCount == 2)
            {
                PhotonNetwork.Instantiate(Player2.name, Player2Pos.position, Quaternion.identity);
            }
            
        }
        else
        {
            Debug.LogError("Photon is not connected.");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayer();
        }
    }
}
