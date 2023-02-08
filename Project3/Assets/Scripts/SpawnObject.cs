using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject spawn;

    [SerializeField] private float spawningInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", spawningInterval, spawningInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void spawnObject()
    {
        Instantiate(spawn, this.transform.position, Quaternion.identity);
    }
}
