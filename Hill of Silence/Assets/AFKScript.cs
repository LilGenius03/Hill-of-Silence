using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AFKScript : MonoBehaviour
{
    public float afkTimeLimit = 180f; 
    private float timeSinceLastInput = 0f;

    void Update()
    { 
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            timeSinceLastInput = 0f;
        }
        else
        {
            timeSinceLastInput += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GoToFirstScene();
        }

        if (timeSinceLastInput >= afkTimeLimit)
        {
            GoToFirstScene();
        }
    }

    void GoToFirstScene()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }
}

