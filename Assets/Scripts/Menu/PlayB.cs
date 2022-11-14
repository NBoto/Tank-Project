using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayB : MonoBehaviour
{
    //public TextMeshProUGUI mySource;
    //public TextMeshProUGUI myDestination;


    // Use this for initialization
    void Start()
    {
        //myDestination.text = PlayerPrefs.GetString("text set"); //This is the new line discussed here!

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void handleClick()
    {
        SceneManager.LoadScene("Grasslands");
        //myDestination.text = mySource.text;

        //PlayerPrefs.SetString("text set", mySource.text); //This is the new line we are discussing in this session!

    }


}
