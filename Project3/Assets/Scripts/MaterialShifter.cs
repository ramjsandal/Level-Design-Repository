using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaterialShifter : MonoBehaviour
{
    public Material material; // public variable to set the material to change color
    private int colorIndex = 0; // private variable to keep track of the current color

    void Start()
    {
        InvokeRepeating("ChangeColor", 1f, 1f); // invoke the ChangeColor function once every second
    }

    void ChangeColor()
    {
        Color[] colors = { Color.black, Color.magenta, Color.red, Color.cyan }; // an array of colors to cycle through
        material.color = colors[colorIndex]; // set the material color to the current color
        colorIndex = (colorIndex + 1) % colors.Length; // increment the color index, making sure to cycle back to the beginning if it exceeds the number of colors
    }
}