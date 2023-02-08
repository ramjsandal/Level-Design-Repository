using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] float sensitivity;

    Vector3 prevMousePos;
    Vector3 mousePos;

    Vector3 jumpVector;
    bool jumpActive = true;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mousePos = Input.mousePosition;
        jumpVector = new Vector3(0, jumpHeight, 0);
    }

    private void Update()
    {
        prevMousePos = mousePos;
        mousePos = Input.mousePosition;
        transform.Rotate(new Vector3(0, (mousePos.x - prevMousePos.x) * sensitivity, 0));

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
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && jumpActive)
        {
            rb.AddForce(jumpVector, ForceMode.Impulse);
            jumpActive = false;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
        jumpActive = true;
    }
}
