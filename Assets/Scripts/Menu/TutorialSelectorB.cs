using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialSelectorB : MonoBehaviour
{
    public void handleClick()
    {
        SceneManager.LoadScene("TargetTutorial");
    }
}