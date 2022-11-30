using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    public Text Score;
    private GameStateManager gsm;

    // Start is called before the first frame update
    void Start()
    {
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = gsm.score.ToString();
    }
}
