using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public bool NoEnemiesLeft;
    public int score;
    public GameObject MoreEnemies;

    //public Image Life1Full;
    //public Image Life2Full;
    //public Image Life3Full;

    public int Life;

    public float lastUsed;

    private void Start()
    {
        Life = 3;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // Don't get destroyed.

        if (instance == null) // If it doesn't exist. Then respawn.
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
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) //Find enemies in scene and see if there are or not.
        {
            NoEnemiesLeft = true;
        }
        else
        {
            NoEnemiesLeft = false; // Allows
        }

        if (Time.time > lastUsed + 0.4f)
        {
            if (SceneManager.GetActiveScene().name == "TargetTutorial" ^ SceneManager.GetActiveScene().name == "Grasslands" ^ SceneManager.GetActiveScene().name == "Desert" ^ SceneManager.GetActiveScene().name == "Artic") //Allow this only on these levels.
            {
                if (Input.GetKey(KeyCode.Space)) //Spacebar
                {
                    GameObject AdditionalEnemy; //Additional Enemies

                    for (int i = 0; i < 5; i++) // Five Enemies to be spawned.
                    {
                        AdditionalEnemy = Instantiate(MoreEnemies, new Vector3(Random.Range(-12, 12), Random.Range(-4, 4), 0), Quaternion.identity); // Spawn these new enemies in a random range.
                    }
                }
                lastUsed = Time.time;
            }
        }

        if (SceneManager.GetActiveScene().name == "TargetTutorial" ^ SceneManager.GetActiveScene().name == "Grasslands" ^ SceneManager.GetActiveScene().name == "Desert" ^ SceneManager.GetActiveScene().name == "Artic") //Allow this only on these levels.
        {
            if (Life < 1) // Death.
            {
                //Destroy(Life1Full.gameObject);
                Destroy(GameObject.Find("Life1-Full"));
                Destroy(GameObject.Find("Life2-Full"));
                Destroy(GameObject.Find("Life3-Full"));
                SceneManager.LoadScene("DestroyedScene");
            }
            else if (Life < 2) // Third Chance.
            {
                Destroy(GameObject.Find("Life2-Full"));
                Destroy(GameObject.Find("Life3-Full"));
                //Destroy(Life2Full.gameObject);
            }
            else if (Life < 3) // Second Chance.
            {
                Destroy(GameObject.Find("Life3-Full"));
                //Destroy(Life3Full.gameObject);
            }
        }
        else
        {
            Life = 3;
        }


        if (SceneManager.GetActiveScene().name == "TargetTutorial" ^ SceneManager.GetActiveScene().name == "Grasslands" ^ SceneManager.GetActiveScene().name == "Desert" ^ SceneManager.GetActiveScene().name == "Artic") //Allow player respawn on these levels.
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length == 0) //If the player doesn't exist.
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Refresh the scene. Player Respawn Mechanic. Lose a life.
                Life -= 1;
            }
        }

        if (SceneManager.GetActiveScene().name == "Menu") //Resets Score when at Menu.
        {
            score = 0;
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


