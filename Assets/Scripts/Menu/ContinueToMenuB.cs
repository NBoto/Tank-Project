using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueToMenuB : MonoBehaviour
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
        SceneManager.LoadScene("Menu");
    }
}
