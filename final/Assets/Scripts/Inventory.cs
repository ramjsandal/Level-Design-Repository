using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int thingsNeeded;
    public string[] stringsArray = new string[7]; // An array of 7 slots that takes in a string
    public int[] countArray = new int[7]; // An array of counters for each string
    public AudioClip[] sfxArray = new AudioClip[5];
    public Text displayText; // The text UI element to display the strings
    private int index;
    private int amtThings;
    public bool enough;
    private GameObject player;

    private void Start()
    {
        enough = false;
        amtThings = 0;
        index = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        // Initialize the arrays with empty strings and zero counts
        for (int i = 0; i < stringsArray.Length; i++)
        {
            stringsArray[i] = "";
            countArray[i] = 0;
        }
    }

    void Update() {
        UpdateText();
    }

    private void UpdateText()
    {
        // Clear the current text
        displayText.text = "";

        // Display the strings and counts in bullet point format
        for (int i = 0; i < stringsArray.Length; i++)
        {
            displayText.text += "• " + stringsArray[i] + " (" + countArray[i] + ")" + "\n";
        }
    }

    // Method to update a specific string and its counter in the arrays
    public void UpdateString(string newString, int newCount)
    {
        int flag = StringExists(newString);
        if (flag != -1)
        {
            // The string is already in the array
            countArray[flag] += 1;
            amtThings += 1;
        }
        else
        {
            stringsArray[index] = newString;
            countArray[index] = newCount;
            amtThings += newCount;
            index += 1;
        }

        if (amtThings >= thingsNeeded)
        {
            enough = true;
        }

        int idx = amtThings - 1;
        if (amtThings >= sfxArray.Length)
        {
            idx = sfxArray.Length - 1;
        }
        AudioSource.PlayClipAtPoint(sfxArray[idx], player.transform.position);
    }

    // Method to check if a string exists in the array returns its
    // index if it exists, returns -1 if it doesnt exist
    public int StringExists(string searchString)
    {
        int idx = -1;

        for (int i = 0; i < stringsArray.Length; i++)
        {
            if (stringsArray[i] == searchString)
            {
                idx = i;
                return idx;
            }
        }

        return idx;
    }

    public void ClearInventory()
    {
        for (int i = 0; i < stringsArray.Length; i++)
        {
            stringsArray[i] = "";
            countArray[i] = 0;
        }
    }
}
