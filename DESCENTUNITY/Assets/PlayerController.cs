using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10.0f;
    private float vert;
    private float horiz;
    private float up;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        vert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horiz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horiz, 0, vert);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(0, 800, 0);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
