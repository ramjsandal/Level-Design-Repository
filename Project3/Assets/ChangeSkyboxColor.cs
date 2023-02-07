using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkyboxColor : MonoBehaviour
{
    private Material skyboxMaterial; // private variable to store the skybox material
    private int colorIndex = 0; // private variable to keep track of the current color

    void Start()
    {
        skyboxMaterial = RenderSettings.skybox; // get the skybox material from RenderSettings
        InvokeRepeating("ChangeColor", 1f, 1f); // invoke the ChangeColor function once every second
    }

    void ChangeColor()
    {
        Color[] colors = { Color.black, Color.magenta, Color.red, Color.cyan }; // an array of colors to cycle through
        skyboxMaterial.SetColor("_Tint", colors[colorIndex]); // set the _Tint property of the skybox material to the current color
        colorIndex = (colorIndex + 1) % colors.Length; // increment the color index, making sure to cycle back to the beginning if it exceeds the number of colors
    }
}

