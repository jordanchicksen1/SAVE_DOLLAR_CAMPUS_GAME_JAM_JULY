using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class connectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("jjjjjjjjjj");


    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("TITLE SCREEN");
        Debug.Log("jjjjjjjjjj");
    }
   
}
