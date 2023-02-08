using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObject : MonoBehaviour
{
    public GameObject target; // public variable to set the target game object to move towards
    public float speed = 0.5f; // public variable to set the speed of movement

    void Start()
    {
       
    }

    void Update() {
         InvokeRepeating("LerpToTarget", 3f, 3f); // invoke the LerpToTarget function once every second
    }


    void LerpToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed); // smoothly move the position of the object towards the target's position, with speed controlled by the speed variable
    }
}

