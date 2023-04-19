

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

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("InvenText").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= interactionRange)
        {
            if (Input.GetKeyDown(interactionKey))
            {
                inventory.AddString(ThisObjectsName, 1);
                // inventory.GetStringCount("objectName") = inventory.GetStringCount("objectName") + 1;
                Destroy(gameObject);
            }
        }
    }
}
