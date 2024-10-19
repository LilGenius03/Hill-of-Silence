using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string url = "https://forms.office.com/Pages/ResponsePage.aspx?id=yxdjdkjpX06M7Nq8ji_V2qYAZhpNQdBIiPiaWPWl20NUMkcxOUozT0UzUkxQTzlJOVY3NU1ZWDFERi4u";
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Play()
    {
        SceneManager.LoadScene("Hill of Silence");
    }

    public void OnApplicationQuit()
    {
       Application.Quit();
        Debug.Log("Quit");
    }

    public void Survey()
    {
        Application.OpenURL(url);
    }
}
