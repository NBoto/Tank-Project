using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public bool NoEnemiesLeft;
    public int score;
    public GameObject MoreEnemies;

    public float lastUsed;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && GameObject.FindGameObjectsWithTag("EnemyDecoy").Length == 0)
        {
            NoEnemiesLeft = true;
        }
        else
        {
            NoEnemiesLeft = false;
        }

        if (Time.time > lastUsed + 0.4f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject AdditionalEnemy;

                for (int i = 0; i < 5; i++)
                {
                    AdditionalEnemy = Instantiate(MoreEnemies, new Vector3(Random.Range(-12, 12), Random.Range(-4, 4), 0), Quaternion.identity);
                }
            }
            lastUsed = Time.time;
        }

    }

        public int getScore()
    {
        return score;
    }

    public void setScore(int s)
    {
        score = s;
    }

    public void adjustScore(int s)
    {
        score += s;
        Debug.Log("Score is " + score);
    }
}


