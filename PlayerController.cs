using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string preset = "";
    private Vector3 playerVel;
    private bool playerGrounded = false;
    CapsuleCollider capc;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        capc = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        playerGrounded = cc.isGrounded;

        playerVel = MovementAPI.GetMovements(playerGrounded, preset);

        //MOVES PLAYER EACH GIVEN (playerVel) DIRECTION AT CURRENT FRAME
        cc.Move(playerVel * Time.deltaTime * 0.5f);

        // UNLOCKS CURSOR
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
