using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Mover mover;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
    }
    
    public void OnMove(CallbackContext context)
    {
        if(mover != null)
            mover.SetInputVector(context.ReadValue<Vector2>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }
    private Player2shoot pLayer2Shoot;
    private Player1shoot pLayer1Shoot;
    
    private void Shoot()
    {
        if (pLayer2Shoot != null)
        {
            pLayer2Shoot.Shooter();
        }
        else if (pLayer1Shoot != null)
        {
            //pLayer1Shoo.Shooter();
        }
    }

    private void Start()
    {
        pLayer2Shoot = GetComponent<Player2shoot>();
        pLayer1Shoot = GetComponent<Player1shoot>();

    }

}
