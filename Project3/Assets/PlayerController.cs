using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camera;

    [SerializeField] float speed;
    [SerializeField] float sensitivity;

    Vector3 prevMousePos;
    Vector3 mousePos;

    void Start()
    {
        mousePos = Input.mousePosition;
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
    }
}
