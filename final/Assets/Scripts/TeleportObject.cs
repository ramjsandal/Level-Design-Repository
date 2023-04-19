using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class TeleportObject : MonoBehaviour
{

    public Transform destinationObj;
    public float teleportRange = 2f;
    [SerializeField] private float speed = 2f;

    private bool atOrigin;
    private bool movable;
    private bool moving;
    private Vector3 originalPosition;
    private GameObject player;
    private GameObject cam;
    private Vector3 destination;

    private void Start()
    {
        atOrigin = true;
        movable = true;
        moving = false;
        destination = destinationObj.position;
        originalPosition = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        // Check if the player is within range and presses the F key
        if (Input.GetKeyDown(KeyCode.F) 
            && LookingAtObject()
            && movable)
        {
            moving = true;
        }

        if (moving)
        {
            movable = false;
            if (atOrigin)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, destination, 
                    speed * Time.deltaTime);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, originalPosition, 
                    speed * Time.deltaTime);
            }
        }

        if (transform.position == originalPosition)
        {
            atOrigin = true;
            movable = true;
            moving = false;
        } 
        
        if (transform.position == destination)
        {
            atOrigin = false;
            movable = true;
            moving = false;
        }
    }

    bool LookingAtObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, teleportRange))
        {
            Debug.Log("Looking at " + hit.transform.name);
            if (hit.transform.parent.position == this.gameObject.transform.position)
            {
                return true;
            }
        }

        return false;
    }

    
}
