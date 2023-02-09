using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
        } 
    }
}
