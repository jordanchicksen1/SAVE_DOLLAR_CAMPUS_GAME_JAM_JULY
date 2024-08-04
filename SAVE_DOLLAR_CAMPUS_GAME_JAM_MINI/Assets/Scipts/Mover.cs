using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Mover : MonoBehaviour
{
    PhotonView view;

    [SerializeField]
    private float MoveSpeed = 3f;

    [SerializeField]
    private int playerIndex = 0;

    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    public Vector2 inputVector = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }



    void Update()
    {
        if (view.IsMine)
        {
            moveDirection = new Vector3(inputVector.x, inputVector.y, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= MoveSpeed;

            controller.Move(moveDirection * Time.deltaTime);
        }

        

    }
}
