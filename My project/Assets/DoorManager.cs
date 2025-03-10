using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public string requiredItem1 = "GoldKey";  // The item required to unlock the door
    public string requiredItem2 = "SilverKey";  // The item required to unlock the door
    public GameObject door;             // The door object that should be unlocked
    public GameObject portal;

    private bool hasGold = false;
    private bool hasSilver = false;

    void OnEnable()
    {
        Inventory.OnItemAdded += CheckForItemAndUnlockDoor;
    }

    void OnDisable()
    {
        Inventory.OnItemAdded -= CheckForItemAndUnlockDoor;
    }

    // Check if the required item was added, and unlock the door if it is
    private void CheckForItemAndUnlockDoor(string itemName)
    {
        if (itemName == requiredItem1)
        {
            hasGold = true;
            if (hasSilver)
            {
                UnlockDoor();
            }
        }
        if (itemName == requiredItem2) 
        {
            hasSilver = true;
            if (hasSilver)
            {
                UnlockDoor();
            }
        }
    }

    // Unlock the door by changing its state (e.g., disabling a collider)
    private void UnlockDoor()
    {
        Debug.Log("The door is unlocked!");
        door.SetActive(false);  // Disable the door object (or unlock it in other ways)
        portal.SetActive(true);
    }
}
