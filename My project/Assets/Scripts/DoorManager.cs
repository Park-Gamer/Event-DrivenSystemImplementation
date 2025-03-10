using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public string requiredItem1 = "GoldKey";  // The 1st item required to unlock the door
    public string requiredItem2 = "SilverKey";  // The 2nd item required to unlock the door
    public GameObject door;   // The door object that will be unlocked
    public GameObject portal; // The portal object that ends level

    private bool hasGold = false; // Check if player has gold key
    private bool hasSilver = false; // Check if player has silver key

    void OnEnable()
    {
        Inventory.OnItemAdded += CheckForItemAndUnlockDoor; // Subscribe to the event
    }

    void OnDisable()
    {
        Inventory.OnItemAdded -= CheckForItemAndUnlockDoor; // Unsubscribe to avoid memory leaks
    }

    // Check if the required item was added, and unlock the door if it is
    private void CheckForItemAndUnlockDoor(string itemName)
    {
        if (itemName == requiredItem1)
        {
            hasGold = true; // Bool checks that player picked up gold key
            if (hasSilver) // If player has both keys open door
            {
                UnlockDoor();
            }
        }
        if (itemName == requiredItem2) 
        {
            hasSilver = true; // Bool checks that player picked up silver key
            if (hasGold) // If player has both keys open door
            {
                UnlockDoor();
            }
        }
    }

    // Unlock the door by changing its state 
    private void UnlockDoor()
    {
        Debug.Log("The door is unlocked!");
        door.SetActive(false);  // Disable the door object 
        portal.SetActive(true); // Enable the portal object
    }
}
