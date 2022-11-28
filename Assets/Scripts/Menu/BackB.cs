using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackB : MonoBehaviour
{
    public void handleClick()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        PauseMenu.Paused = false;
    }
}
