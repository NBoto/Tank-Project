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
    public GameStateManager gsm;

    /// USES: https://www.youtube.com/watch?v=jvtFUfJ6CP8
    public AIPath AIPath;
    public AIDestinationSetter AIDesSetter;
    ///////////////////

    //Input keys vars//
    public string Shoot;
    public float lastFired;
    ///////////////////


    void Start()
    {
        GameObject gs = GameObject.Find("GameStateManager");
        GameObject Player = GameObject.Find("PlayerTank");
        AIDesSetter.target = Player.transform;
        gsm = gs.GetComponent<GameStateManager>();
    }

    private void fireBullet()
    {
        GameObject tmpBullet;

        if (Time.time > lastFired + 1)
        {
            tmpBullet = Instantiate(
                           Shell,
                           this.transform.position + this.transform.up * 1,
                            this.transform.rotation
                        );

            lastFired = Time.time;
        }

    }

    void Update()
    {
        GameObject Player = GameObject.Find("PlayerTank");
        AIDesSetter.target = Player.transform;

        if (Player)
        {
            Vector2 FaceTo = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
            TurretObj.transform.right = FaceTo;
        }

        //if (TankRigid.velocity.y >= 0 ^ TankRigid.velocity.x >= 0)
        if (AIPath.hasPath)
        {
            if (!Enginel.isPlaying)
            {
                Enginel.Play();
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
            }
            if (Enginer.isPlaying)
            {
                Enginer.Stop();
            }
        }
    }

    private void OnTriggerStay2D(Collision2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            GameObject TmpShell;

            if (Time.time > lastFired + 0.4f)
            {
                TmpShell = Instantiate(Shell, TurretObj.transform.position + (TurretObj.transform.right * 1.2f), TurretObj.transform.rotation * Quaternion.Euler(0f, 0f, -90f));
                lastFired = Time.time;
            }
        }
    }

}