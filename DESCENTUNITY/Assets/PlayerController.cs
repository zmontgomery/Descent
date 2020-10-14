using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;
    public float accel = 0.4f;
    public float deccel = 0.4f;
    public float gravity = -9.81f;
    public float JumpHeight = 4.0f;
    private bool playerGrounded = false;
    private float vert;
    private float horiz;
    private float ykeyboard;
    private float xkeyboard;
    private float Dspeed = 0.0f;
    private float Aspeed = 0.0f;
    private float Wspeed = 0.0f;
    private float Sspeed = 0.0f;
    private Vector3 playerGrav;
    private Vector3 playerVel;
    CapsuleCollider capc;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        capc = GetComponent<CapsuleCollider>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        playerGrounded = cc.isGrounded;

        ykeyboard = Input.GetAxis("Vertical");
        xkeyboard = Input.GetAxis("Horizontal");
        if (playerGrounded){
            if(xkeyboard > 0.0f){
                if (Dspeed < speed){
                    Dspeed += accel;
                    if(Dspeed > speed){
                        Dspeed = speed;
                    }
                }
            }
            else if(Dspeed > 0){
                Dspeed -= deccel;
                if(Dspeed < 0){
                    Dspeed = 0;
                }
            }
            if(xkeyboard < 0.0f){
                if (Aspeed > -speed){
                    Aspeed -= accel;
                    if(Aspeed < -speed){
                        Aspeed = -speed;
                    }
                }
            }
            else if(Aspeed < 0){
                Aspeed += deccel;
                if(Aspeed > 0){
                    Aspeed = 0;
                }
            }
            if(ykeyboard > 0.0f){
                if (Wspeed < speed){
                    Wspeed += accel;
                    if(Wspeed > speed){
                        Wspeed = speed;
                    }
                }
            }
            else if(Wspeed > 0){
                Wspeed -= deccel;
                if(Wspeed < 0){
                    Wspeed = 0;
                }
            }
            if(ykeyboard < 0.0f){
                if (Sspeed > -speed){
                    Sspeed -= accel;
                    if(Sspeed < -speed){
                        Sspeed = -speed;
                    }
                }
            }
            else if(Sspeed < 0){
                Sspeed += deccel;
                if(Sspeed > 0){
                    Sspeed = 0;
                }
            }
        }
        

        horiz = Dspeed + Aspeed;
        vert = Wspeed + Sspeed;




        playerVel = new Vector3(horiz, 0, vert);


        


        //playerVel.x += timeHeldW * Time.deltaTime;
        //playerVel.z += timeHeldA * Time.deltaTime;
        cc.Move(playerVel * Time.deltaTime * 2);


        

        if (playerGrounded && playerGrav.y < 0){
            playerGrav.y = 0f;
        }

        playerGrav.y += gravity * Time.deltaTime;
        cc.Move(playerGrav * Time.deltaTime);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
