using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // When colliding with player game object
        {
            EndScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("demoScene_free"); // Loads the demo scene
    }
    public void EndScene()
    {
        Cursor.lockState = CursorLockMode.None; // Sets Cursor to visable state
        SceneManager.LoadScene("EndScene"); // Loads the ending scene
    }
    public void CloseGame()
    {
        Application.Quit(); // Closes game
    }
}
