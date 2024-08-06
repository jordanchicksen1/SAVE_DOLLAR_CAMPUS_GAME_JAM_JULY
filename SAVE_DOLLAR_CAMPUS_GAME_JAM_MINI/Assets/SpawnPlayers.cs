using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject Player1;
    public GameObject Player2;

    public Transform[] Pos;

    private void Start()
    {
        Transform randomPosition = Pos[Random.Range(0, Pos.Length)];
        PhotonNetwork.Instantiate(Player1.name, randomPosition.position, Quaternion.identity);

    }








}
