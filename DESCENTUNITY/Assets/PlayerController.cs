using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
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
        UnityEngine.Debug.Log(Physics.OverlapBox(transform.position - new Vector3(0, 1, 0), new Vector3(0.5f, 0.2f, 0.5f), Quaternion.identity, 0));

        vert = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        horiz = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horiz, 0, vert);

        if (Input.GetKeyDown("space"))
        {
            if (Physics.OverlapBox(transform.position - new Vector3(0, 1, 0), new Vector3(0.5f, 0.2f, 0.5f), Quaternion.identity, 0) != null)
            {
                rb.AddForce(0, 100, 0);  
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }
}
