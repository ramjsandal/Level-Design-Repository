using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(transform.forward * 5);
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, .01f);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -.01f);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-.01f, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(.01f, 0, 0);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(25, 25, 500, 100), "Looks like a long walk, " +
                                              "maybe theres a quicker way?");
    }
}
