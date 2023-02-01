using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] GameObject goal;

    bool ended;
    float inGameTime;

    void Start()
    {
        ended = false;
        inGameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            inGameTime += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (!ended && c.gameObject == goal)
        {
            ended = true;
        }
    }

    void OnGUI()
    {
        GUI.Button(new Rect(20, 20, 150, 30), "Time: " + inGameTime);
    }
}
