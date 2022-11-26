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
            if (gsm.NoEnemiesLeft == true)
            {
                SceneManager.LoadScene("Desert");
            }
        }
    }

  }
