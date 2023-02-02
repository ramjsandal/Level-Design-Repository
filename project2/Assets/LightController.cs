using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] dimLights;
    public Light[] brightLights;

    void Start()
    {
        // Set dimly lit lights
        for (int i = 0; i < dimLights.Length; i++)
        {
            dimLights[i].intensity = 0.5f;
        }

        // Set fully bright lights
        for (int i = 0; i < brightLights.Length; i++)
        {
            brightLights[i].intensity = 1f;
        }
    }
}