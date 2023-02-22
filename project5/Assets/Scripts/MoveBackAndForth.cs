using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    [SerializeField] private Transform endPoint;

    [SerializeField] private float movespeed;

    private Vector3 startingPoint;

    private Vector3 endPosition;

    private Transform t;

    private bool forwards;
    // Start is called before the first frame update
    void Start()
    {
        t = this.transform;
        startingPoint = t.transform.position;
        forwards = true;
        endPosition = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(t.position, endPosition) < 1)
        {
            forwards = false;
        }
        if (Vector3.Distance(t.position, startingPoint) < 1)
        {
            forwards = true;
        }


        if (forwards)
        {
            t.position = Vector3.MoveTowards(t.position, endPosition, 
                Time.deltaTime * movespeed);
        }
        else
        {
            t.position = Vector3.MoveTowards(t.position, startingPoint, 
                Time.deltaTime * movespeed);
        }
        
    }
    
}
