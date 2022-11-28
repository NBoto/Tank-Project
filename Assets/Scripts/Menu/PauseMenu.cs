using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseUI;

    //Refence tutorial: https://www.youtube.com/watch?v=JivuXdrIHK0

    void Start()
    {
        Paused = false;
        PauseUI.SetActive(false);
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

}
