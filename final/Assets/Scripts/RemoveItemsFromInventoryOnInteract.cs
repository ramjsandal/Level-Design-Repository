using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class RemoveItemsFromInventoryOnInteract : MonoBehaviour
{
    private GameObject cam;
    private Inventory inv;
    public float interactRange = 2f;
    private VideoPlayer vp;
    [SerializeField] private VideoClip clip;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        inv = GameObject.FindGameObjectWithTag("InvenText").GetComponent<Inventory>();
        vp = GameObject.FindGameObjectWithTag("VidPlayer").GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && LookingAtObject())
        {
            inv.ClearInventory();
            vp.clip = clip;
            vp.Play();
            vp.isLooping = false;
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
