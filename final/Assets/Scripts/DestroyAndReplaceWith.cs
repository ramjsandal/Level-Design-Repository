using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyAndReplaceWith : MonoBehaviour
{
    [SerializeField] private GameObject spawnable;

    [SerializeField] private float interactRange = 2f;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)
            && Vector3.Distance(this.transform.position, player.transform.position) < interactRange)
        {
            Instantiate(spawnable, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
