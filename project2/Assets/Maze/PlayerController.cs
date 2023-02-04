using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            }
        }
    }
}
