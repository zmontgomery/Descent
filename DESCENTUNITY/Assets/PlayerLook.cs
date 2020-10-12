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
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {

        MouseY += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-MouseY, 0, 0);

    }

}
