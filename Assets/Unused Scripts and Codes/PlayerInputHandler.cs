﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private Mover mover;

    [SerializeField]
    //private Image playerMesh;

    private PlayerControls controls;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        controls = new PlayerControls();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        //playerMesh.material = config.playerImage.material;
        config.Input.onActionTriggered += Input_onActionTriggered;
    }

     private void Input_onActionTriggered(CallbackContext obj)
     {
         if (obj.action.name == controls.Player.Move.name)
         {
             OnMove(obj);
         }
     }
    
     public void OnMove(CallbackContext context)
     {
         if (mover != null)
             mover.SetInputVector(context.ReadValue<Vector2>());
     }

}