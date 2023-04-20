using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeForAudioClipOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private PlayerController pc;
    private GameObject player;
    private float clipLength;
    private bool playing;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        pc = player.GetComponent<PlayerController>();
        clipLength = clip.length;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            clipLength -= Time.deltaTime;
            pc.enabled = false;

            if (clipLength <= 0)
            {
                pc.enabled = true;
                playing = false;
                this.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(clip, player.transform.position);  
            playing = true;
        }
    }
}
