using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitQuoteScene : MonoBehaviour
{
    public float ExitTime = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        ExitTime -= Time.deltaTime;

        if(ExitTime <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}
