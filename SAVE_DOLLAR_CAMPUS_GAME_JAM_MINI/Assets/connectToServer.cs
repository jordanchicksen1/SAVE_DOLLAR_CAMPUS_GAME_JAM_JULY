using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class connectToServer : MonoBehaviourPunCallbacks
{

    public TMP_InputField Username;
    public TextMeshProUGUI ButtonText; //Change tio TextMeshPro

    void Start()
    {
    }

    public void OnClickConnect()
    {
        if (Username.text.Length >= 1)
        {
            PhotonNetwork.NickName = Username.text;
            ButtonText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

        }
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("Lobby");


    }

    /*public override void OnJoinedLobby()
    {
        Debug.Log("jjjjjjjjjj");
    }*/
   
}
