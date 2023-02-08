using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBossController : MonoBehaviour
{
    public float speed = 12.0f; // public variable to set the movement speed

      // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime; // move forward when 'w' is pressed
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime; // move backward when 's' is pressed
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * speed * 7f * Time.deltaTime); // turn left when 'a' is pressed
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * speed * 7f  * Time.deltaTime); // turn right when 'd' is pressed
        }
    }
}




