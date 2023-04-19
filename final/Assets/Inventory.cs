using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string[] stringsArray = new string[7]; // An array of 7 slots that takes in a string
    public Text displayText; // The text UI element to display the strings

    private void Start()
    {
        // Initialize the array with empty strings
        for (int i = 0; i < stringsArray.Length; i++)
        {
            stringsArray[i] = "";
        }
    }

    void Update() {
        UpdateText();
    }

    private void UpdateText()
    {
        // Clear the current text
        displayText.text = "";

        // Display the strings in bullet point format
        for (int i = 0; i < stringsArray.Length; i++)
        {
            displayText.text += "• " + stringsArray[i] + "\n";
        }
    }

    // Method to update a specific string in the array
    public void UpdateString(int index, string newString)
    {
        stringsArray[index] = newString;
        UpdateText();
    }

    // Method to clear all strings in the array
    public void ClearStrings()
    {
        for (int i = 0; i < stringsArray.Length; i++)
        {
            stringsArray[i] = "";
        }
        UpdateText();
    }

    // Method to check if a string exists in the array
    public bool StringExists(string searchString, out int index)
    {
        index = -1;

        for (int i = 0; i < stringsArray.Length; i++)
        {
            if (stringsArray[i] == searchString)
            {
                index = i;
                return true;
            }
        }

        return false;
    }

    // Method to get the index of a string in the array
    public int GetIndexOfString(string searchString)
    {
        int index;
        StringExists(searchString, out index);
        return index;
    }

    // Method to add a string to the next available empty slot
    public bool AddString(string newString)
    {
        for (int i = 0; i < stringsArray.Length; i++)
        {
            if (stringsArray[i] == "")
            {
                UpdateString(i, newString);
                return true;
            }
        }

        return false;
    }
}
