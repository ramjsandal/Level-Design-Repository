using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 input, moveDirection;
    public float jumpHeight = 2;
    public float gravity = 9.81f;
    public float airControl = 10f;

    public float moveSpeed = 10;

    public bool canMove = true;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        input *= moveSpeed;

        //controller.Move(input * Time.deltaTime);

        if (controller.isGrounded)
        {
            moveDirection = input;
            // We can jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            } else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            // We are midair
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        Vector3 final = new Vector3(input.x, input.y + moveDirection.y, input.z);

        if (canMove)
        {
            controller.Move(final* Time.deltaTime);
        }
    }
}
