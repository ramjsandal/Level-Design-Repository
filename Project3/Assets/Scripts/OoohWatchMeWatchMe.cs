using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OoohWatchMeWatchMe : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(0, 180, 0);
    }
}
