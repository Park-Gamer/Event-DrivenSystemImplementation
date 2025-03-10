using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI inventoryText; // Text for inventory UI
    public AudioSource audioSource; // Reference to audio source
    public AudioClip itemAddedSound; // Audio sound file

    void OnEnable()
    {
        Inventory.OnItemAdded += UpdateUI;  // Subscribe to the event
    }

    void OnDisable()
    {
        Inventory.OnItemAdded -= UpdateUI;  // Unsubscribe to avoid memory leaks
    }

    // Update UI and play sound when an item is added
    private void UpdateUI(string itemName)
    {
        // Update the inventory text UI
        inventoryText.text += "\n" + itemName;

        // Play the sound effect
        if (itemAddedSound != null)
        {
            audioSource.PlayOneShot(itemAddedSound);
        }
    }
}
