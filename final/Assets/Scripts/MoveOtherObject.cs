using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOtherObject : MonoBehaviour
{
    [SerializeField] private TeleportObject other;
    [SerializeField] private float interactRange = 2f;
    private GameObject cam;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && LookingAtObject())
        {
            other.moving = true;
        }
    }
    
    bool LookingAtObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange))
        {
            Debug.Log("Looking at " + hit.transform.name);
            if (hit.transform.position == this.gameObject.transform.position)
            {
                return true;
            }
        }

        return false;
    }
}
