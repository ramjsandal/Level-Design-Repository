using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnCond : MonoBehaviour
{

    private TeleportObject tp;
    private Inventory inv;
    void Start()
    {
        tp = GetComponent<TeleportObject>();
        tp.enabled = false;
        inv = GameObject.FindGameObjectWithTag("InvenText").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inv.enough)
        {
            tp.enabled = true;
            tp.moving = true;
        }
    }
}
