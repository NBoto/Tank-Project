using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankScript : MonoBehaviour
{
    public Rigidbody2D TankRigid;
    public GameObject TurretObj;
    public GameObject Shell;
    public ParticleSystem Enginel;
    public ParticleSystem Enginer;

    public GameObject[] targets;
    public GameObject[] waypoints;
    public GameStateManager gsm;
    List<GameObject> validTargets;
    GameObject currentTarget;
    private int timeToMove;
    private int currentWaypoint;

    //Input keys vars//
    public string Shoot;
    ///////////////////

    public float lastFired;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gs = GameObject.Find("GameStateManager");
        gsm = gs.GetComponent<GameStateManager>();

        GameObject ship = GameObject.Find("Player");

        validTargets = new List<GameObject>();
        timeToMove = 0;
    }

    private void moveForward()
    {
        Enginel.Play();
        Enginer.Play();
        TankRigid.transform.Translate(new Vector3(4f, 0f, 0f) * Time.deltaTime * 1);
    }

    private void slowDown()
    {
        TankRigid.transform.Translate(new Vector3(-4f, -0f, 0f) * Time.deltaTime * 1);
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

    void findValidTargets()
    {
            currentTarget = GameObject.Find("PlayerTank");

            if (currentTarget)
            {
                currentTarget.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f);
            }
        }

    bool moveToWaypoint()
    {
        RaycastHit2D[] hit;
        bool found = false;
        GameObject point = waypoints[currentWaypoint];


        hit = Physics2D.RaycastAll(this.transform.position, this.transform.up, Mathf.Infinity);

        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].transform.gameObject == waypoints[currentWaypoint])
            {
                found = true;
            }
        }

        if (found == false)
        {
            turnLeft();
            return false;
        }

        if (found == true)
        {
            hit = Physics2D.RaycastAll(this.transform.position, this.transform.up, Mathf.Infinity);

            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].transform.gameObject == waypoints[currentWaypoint])
                {
                    if (hit[i].distance > 12)
                    {
                        moveForward();
                    }

                    if (hit[i].distance < 4)
                    {
                        slowDown();
                    }

                    if (hit[i].distance < 2)
                    {
                        Debug.Log("Distance is " + hit[i].distance);
                        timeToMove = 0;
                        return true;
                    }
                }
            }
        }



        return false;
    }

    void turnToFaceTarget()
    {
        RaycastHit2D hit;

        Debug.DrawRay(this.transform.localPosition, transform.up * 1000, Color.green);
        hit = Physics2D.Raycast(this.transform.position, this.transform.up, Mathf.Infinity);

        Debug.Log("Facing target");

        if (!hit.collider || hit.transform.gameObject != currentTarget)
        {
            turnLeft();

        }
        else
        {
            fireBullet();
            timeToMove = 0;
        }


    }
    // Update is called once per frame
    void Update()
    {
        bool ret;


        timeToMove += 1;

        if (timeToMove >= 180)
        {
            ret = moveToWaypoint();

            if (ret == true)
            {

                currentWaypoint += 1;
                timeToMove = 0;

                if (currentWaypoint >= waypoints.Length)
                {

                    currentWaypoint = 0;
                }
            }

        }
        else
        {
            if (!currentTarget)
            {
                findValidTargets();
            }

            turnToFaceTarget();

        }
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