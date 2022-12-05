using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using UnityEngine;
using Pathfinding;

public class EnemyTankScript : MonoBehaviour
{
    public Rigidbody2D TankRigid;
    public GameObject TurretObj;
    public GameObject Shell;
    public ParticleSystem Enginel;
    public ParticleSystem Enginer;
    public AudioSource EngineSFX;
    public AudioSource FireSFX;
    public GameStateManager gsm;

    /// USES: https://www.youtube.com/watch?v=jvtFUfJ6CP8
    public AIPath AIPath;
    public AIDestinationSetter AIDesSetter;
    ///////////////////

    bool ChasePlayer;
    public GameObject Waypoint;
    private GameObject PatrolPoint;

    //Input keys vars//
    public string Shoot;
    public float lastFired;
    public float lastSpawned;
    ///////////////////


    void Start()
    {
        GameObject gs = GameObject.Find("GameStateManager");
        GameObject Player = GameObject.Find("PlayerTank");
        AIDesSetter.target = Player.transform;
        gsm = gs.GetComponent<GameStateManager>();
    }

    void Update()
    {
        GameObject Player = GameObject.Find("PlayerTank");

        if (!ChasePlayer) // If not chasing player.
        {
            if (!PatrolPoint) // When there is no current waypoint.
            {
                PatrolPoint = Instantiate(Waypoint, new Vector3(Random.Range(-20, 20), Random.Range(-16, 16), 0), Quaternion.identity); // Spawn a waypoint in a random position.
            }
            if (PatrolPoint) // When there is a current waypoint.
            {
                AIDesSetter.target = PatrolPoint.transform; // Move to waypoint.
            }
        }
        else // If chasing player.
        {
            if (Player)
            {
                AIDesSetter.target = Player.transform; // Move to player.
                Vector2 FaceTo = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y); // get player position.
                TurretObj.transform.right = FaceTo; // face current axis towards player.
            }
        }

        //if (TankRigid.velocity.y >= 0 ^ TankRigid.velocity.x >= 0)
        if (AIPath.hasPath)
        {
            if (!Enginel.isPlaying)
            {
                Enginel.Play();
                EngineSFX.Play();
            }
            if (!Enginer.isPlaying)
            {
                Enginer.Play();
            }
        }
        else
        {
            if (Enginel.isPlaying)
            {
                Enginel.Stop();
                EngineSFX.Stop();
            }
            if (Enginer.isPlaying)
            {
                Enginer.Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            ChasePlayer = true;
        }
    }
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            GameObject TmpShell;

            if (Time.time > lastFired + 1f)
            {
                FireSFX.Play();
                TmpShell = Instantiate(Shell, TurretObj.transform.position + (TurretObj.transform.right * 1.2f), TurretObj.transform.rotation * Quaternion.Euler(0f, 0f, -90f)); // shoot.
                lastFired = Time.time;
            }
        }
        if (trigger.CompareTag("Waypoint"))
        {
            if (Time.time > lastSpawned + 2f)
            {
                Destroy(PatrolPoint);
                lastSpawned = Time.time;
            }
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            ChasePlayer = false;
        }
    }

}