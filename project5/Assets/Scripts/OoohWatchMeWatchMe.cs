using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OoohWatchMeWatchMe : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float xOffset;

    [SerializeField] private float yOffset;

    [SerializeField] private float zOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(xOffset, yOffset, zOffset);
    }
}
