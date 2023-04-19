using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public string[] stringsArray = new string[7]; // An array of 7 slots that takes in a string
    public int[] countArray = new int[7]; // An array of counters for each string
    public Text displayText; // The text UI element to display the strings

    private void Start()
    {
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
    public void UpdateString(int index, string newString, int newCount)
    {
        stringsArray[index] = newString;
        countArray[index] = newCount;
        UpdateText();
    }

    // Method to clear all strings and counters in the arrays
    public void ClearStrings()
    {
        for (int i = 0; i < stringsArray.Length; i++)
        {
            stringsArray[i] = "";
            countArray[i] = 0;
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
    public bool AddString(string newString, int newCount)
    {
        for (int i = 0; i < stringsArray.Length; i++)
        {
            if (stringsArray[i] == "")
            {
                UpdateString(i, newString, newCount);
                return true;
            }
        }

        return false;
    }
}
