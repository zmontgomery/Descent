using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class CapsuleLook : MonoBehaviour
{
    private float MouseX;

    void Start()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {

        MouseX += Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(0, MouseX, 0);

    }

}
