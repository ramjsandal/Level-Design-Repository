using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemsFromInventoryOnInteract : MonoBehaviour
{
    private GameObject cam;
    private Inventory inv;
    public float interactRange = 2f;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        inv = GameObject.FindGameObjectWithTag("InvenText").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && LookingAtObject())
        {
            inv.ClearInventory();
        }
    }

    bool LookingAtObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactRange))
        {
            Debug.Log("Looking at " + hit.transform.name);
            try
            {
                if (hit.transform.position == this.gameObject.transform.position)
                {
                    return true;
                }
            }
            catch (NullReferenceException e)
            {
                return false;
            }
        }

        return false;
    }
}
