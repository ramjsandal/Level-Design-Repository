using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] float dashLength;
    [SerializeField] float dashCooldown;
    [SerializeField] float sensitivity;

    Vector3 prevMousePos;
    Vector3 mousePos;

    Vector3 jumpVector;
    bool jumpActive = true;

    float timeSinceDash = 0;
    bool dashActive = true;

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

        if (!dashActive)
        {
            if (timeSinceDash >= dashCooldown)
            {
                dashActive = true;
            }
            else
            {
                timeSinceDash += Time.deltaTime;
            }
        }

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

        if (Input.GetKey(KeyCode.LeftShift) && dashActive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-dashLength, 0, 0);
                dashActive = false;
                timeSinceDash = 0;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(dashLength, 0, 0);
                dashActive = false;
                timeSinceDash = 0;
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        jumpActive = true;
    }
}
