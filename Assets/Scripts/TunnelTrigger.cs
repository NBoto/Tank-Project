using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelTrigger : MonoBehaviour
{
    public GameStateManager gsm;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
            if (gsm.NoEnemiesLeft == true & SceneManager.GetSceneByName("TargetTutorial").isLoaded)
            {
                SceneManager.LoadScene("LevelSelector");
            }
            if (gsm.NoEnemiesLeft == true & SceneManager.GetSceneByName("Grasslands").isLoaded)
            {
                SceneManager.LoadScene("Desert");
            }
            if (gsm.NoEnemiesLeft == true & SceneManager.GetSceneByName("Desert").isLoaded)
            {
                SceneManager.LoadScene("Artic");
            }
            if (gsm.NoEnemiesLeft == true & SceneManager.GetSceneByName("Artic").isLoaded)
            {
                SceneManager.LoadScene("VictoryScene");
            }
            if (gsm.NoEnemiesLeft == true & SceneManager.GetSceneByName("VictoryScene").isLoaded)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

  }
