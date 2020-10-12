using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float MouseX;
    private float MouseY;

    void Start()
    {

    }

    void Update()
    {

        MouseX += Input.GetAxis("Mouse X");
        MouseY += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-MouseY, MouseX, 0);

    }

}
