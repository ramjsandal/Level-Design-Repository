using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    [SerializeField] private TeleportObject tp;
    void Start()
    {
        tp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tp.enabled = true;
            tp.moving = true;
        }
    }
}
