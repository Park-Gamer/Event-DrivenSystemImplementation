using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("demoScene_free");
    }
    public void EndScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("EndScene");
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
