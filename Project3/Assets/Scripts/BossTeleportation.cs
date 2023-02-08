using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleportation : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ; // public variables to set the range of the area to teleport in
    public float smallTel = 2f;
    public float bigTel = 4f;

    void Start()
    {
        InvokeRepeating("Teleport", 3f, Random.Range(smallTel, bigTel)); // invoke the Teleport function every 3 to 5 seconds
    }

    void Teleport()
    {
        float newX = Random.Range(minX, maxX); // generate a random X position within the specified range
        float newZ = Random.Range(minZ, maxZ); // generate a random Z position within the specified range
        transform.position = new Vector3(newX, transform.position.y, newZ); // set the position of the object to the new random X and Z values
    }
}

