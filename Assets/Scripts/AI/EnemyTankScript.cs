using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using UnityEngine;

public class EnemyTankScript : MonoBehaviour
{
    public Rigidbody2D TankRigid;
    public GameObject TurretObj;
    public GameObject Shell;
    public ParticleSystem Enginel;
    public ParticleSystem Enginer;


    public GameStateManager gsm;

    //Input keys vars//
    public string Shoot;
    ///////////////////

    public float lastFired;

    //AI ADDITIONS//
    public GameObject GOTOPOSITION;
    private int timeToMove;
    private bool IsSpawned;
    ////////////////


    void Start()
    {
        GameObject gs = GameObject.Find("GameStateManager");
        gsm = gs.GetComponent<GameStateManager>();
        timeToMove = 0;
    }

    private void moveForward()
    {
        Enginel.Play();
        Enginer.Play();
        TankRigid.transform.Translate(new Vector3(0f, 4f, 0f) * Time.deltaTime * 1);
    }

    private void slowDown()
    {
        TankRigid.transform.Translate(new Vector3(0f, -4f, 0f) * Time.deltaTime * 1);
    }

    private void turnLeft()
    {
        TankRigid.transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime * 1);
    }

    private void turnRight()
    {
        TankRigid.transform.Rotate(new Vector3(0f, 0f, -200f) * Time.deltaTime * 1);

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
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //GameObject TmpShell;

        //Debug.Log(lastFired);

        //if (Time.time > lastFired + 0.4f)
        //{
            //TmpShell = Instantiate(Shell, TurretObj.transform.position + (TurretObj.transform.right * 1.2f), TurretObj.transform.rotation * Quaternion.Euler(0f, 0f, -90f));
            //lastFired = Time.time;
        //}

    }
}