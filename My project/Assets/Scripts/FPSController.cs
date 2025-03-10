using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Controls how fast the camera moves

    public Transform playerBody; // Transform of the player game object

    float xRotation = 0f; // Variable for calculating rotation

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor so it doesn't appear
    }

    void Update()
    {
        // Assign mouse input to float variables
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Set local transform based off of calculated rotation
        playerBody.Rotate(Vector3.up * mouseX); 
    }
}
