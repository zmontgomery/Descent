using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MovementAPI : MonoBehaviour
{

    public static float playerspeed = 3.0f;
    public static float accel = 4f;
    public static float airAccel = 0.2f;
    public static float friction = 4f;
    public static float airFriction = 0.2f;
    public static float gravity = -9.81f;
    public static float jumpHeight = 4.0f;
    private static bool playerGrounded = false;
    private static float vert;
    private static float horiz;
    private static float ykeyboard;
    private static float xkeyboard;
    private static float Dspeed = 0.0f;
    private static float Aspeed = 0.0f;
    private static float Wspeed = 0.0f;
    private static float Sspeed = 0.0f;
    private static Vector3 playerVel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    static float acceleratePOS(float dirspeed, float accel){
        if (dirspeed < playerspeed){
            dirspeed += accel;
            if(dirspeed > playerspeed){
                dirspeed = playerspeed;
            }
        }
        return dirspeed;
    }

    static float accelerateNEG(float dirspeed, float accel){
        if (dirspeed > -playerspeed){
            dirspeed -= accel;
            if(dirspeed < -playerspeed){
                dirspeed = -playerspeed;
            }
        }
        return dirspeed;
    }

    static float decceleratePOS(float dirspeed, float friction){
        dirspeed -= friction;
        if(dirspeed < 0){
            dirspeed = 0;
        }
        return dirspeed;
    }

    static float deccelerateNEG(float dirspeed, float friction){
        dirspeed += friction;
        if(dirspeed > 0){
            dirspeed = 0;
        }
        return dirspeed;
    }

    static void changeHorizontalVel(bool status){
        if (status == false){
            if(xkeyboard > 0.0f){
            Dspeed = acceleratePOS(Dspeed, airAccel);
            }
            else if(Dspeed > 0){
                Dspeed = decceleratePOS(Dspeed, airFriction);
            }
            if(xkeyboard < 0.0f){
                Aspeed = accelerateNEG(Aspeed, airAccel);
            }
            else if(Aspeed < 0){
                Aspeed = deccelerateNEG(Aspeed, airFriction);
            }
            if(ykeyboard > 0.0f){
                Wspeed = acceleratePOS(Wspeed, airAccel);
            }
            else if(Wspeed > 0){
                Wspeed = decceleratePOS(Wspeed, airFriction);
            }
            if(ykeyboard < 0.0f){
                Sspeed = accelerateNEG(Sspeed, airAccel);
            }
            else if(Sspeed < 0){
                Sspeed = deccelerateNEG(Sspeed, airFriction);
            }
        }
        if (status == true){
            if(xkeyboard > 0.0f){
                Dspeed = acceleratePOS(Dspeed, accel);
            }
            else if(Dspeed > 0){
                Dspeed = decceleratePOS(Dspeed, friction);
            }
            if(xkeyboard < 0.0f){
                Aspeed = accelerateNEG(Aspeed, accel);
            }
            else if(Aspeed < 0){
                Aspeed = deccelerateNEG(Aspeed, friction);
            }
            if(ykeyboard > 0.0f){
                Wspeed = acceleratePOS(Wspeed, accel);
            }
            else if(Wspeed > 0){
                Wspeed = decceleratePOS(Wspeed, friction);
            }
            if(ykeyboard < 0.0f){
                Sspeed = accelerateNEG(Sspeed, accel);
            }
            else if(Sspeed < 0){
                Sspeed = deccelerateNEG(Sspeed, friction);
            }
        }
    }


    public static Vector3 GetMovements(bool playerGrounded, string preset = "")
    {
        if(preset == "Overwatch"){
            playerspeed = 13.0f;
            accel = 10f;
            airAccel = 0.1f;
            friction = 10f;
            airFriction = 0.07f;
            gravity = -10f;
            jumpHeight = 3.6f;
        }

        ykeyboard = Input.GetAxis("Vertical");
        xkeyboard = Input.GetAxis("Horizontal");

        //ill explain later
        changeHorizontalVel(playerGrounded);

        //ADDS HORIZONTAL COMPONENTS TO MOVE VECTOR
        horiz = Dspeed + Aspeed;
        vert = Wspeed + Sspeed;
        playerVel.x = horiz;
        playerVel.z = vert;


        //JUMP FUNCTION
        if (playerGrounded && Input.GetKeyDown("space"))
        {
            playerVel.y += jumpHeight;
        }

        //MAKES SURE PLAYER STAYS GROUNDED WHEN GROUNDED
        if (playerGrounded && playerVel.y < 0){
            playerVel.y = 0f;
        }
        playerVel.y += gravity * Time.deltaTime;

        return playerVel;
    }

}
