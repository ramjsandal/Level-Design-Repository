using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Transform teleportObj; // Renamed from "TeleportObject"
    public Transform teleportPosition1;
    public Transform teleportPosition2;
    public float teleportRange = 2f;

    private bool isTeleporting = false;

    void Update()
    {
        // Check if the player is within range and presses the F key
        if (Input.GetKeyDown(KeyCode.F) && !isTeleporting)
        {
            float distanceToTeleport = Vector3.Distance(teleportObj.position, transform.position);
            if (distanceToTeleport <= teleportRange)
            {
                // Teleport the object to the other position
                Vector3 teleportPosition = (teleportObj.position == teleportPosition1.position) ? teleportPosition2.position : teleportPosition1.position;
                StartCoroutine(TeleportObject(teleportPosition));
            }
        }
    }

    IEnumerator TeleportObject(Vector3 newPosition)
    {
        isTeleporting = true;
        yield return new WaitForSeconds(0.5f); // Add a delay to give the impression of teleportation
        teleportObj.position = newPosition;
        isTeleporting = false;
    }

    public bool IsAtPositionA()
    {
        return teleportObj.position == teleportPosition1.position;
    }
}
