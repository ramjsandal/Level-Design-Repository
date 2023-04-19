

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    public float interactionRange = 2f; // The range within which the player can interact
    public KeyCode interactionKey = KeyCode.F; // The key to press for interaction
    public string ThisObjectsName;

    private GameObject inventoryObject; // The object with the Inventory component

    private GameObject player; // The player object
    private Inventory inventory; // The Inventory component on the object
    private GameObject cam;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("InvenText").GetComponent<Inventory>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= interactionRange)
        {
            if (Input.GetKeyDown(interactionKey) && LookingAtObject())
            {
                inventory.UpdateString(ThisObjectsName, 1);
                // inventory.GetStringCount("objectName") = inventory.GetStringCount("objectName") + 1;
                Destroy(gameObject);
            }
        }
    }
    
    bool LookingAtObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionRange))
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
