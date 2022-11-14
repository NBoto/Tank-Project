using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankScript : MonoBehaviour
{
    public Rigidbody2D TankRigid;
    public GameObject TurretObj;
    public GameObject Shell;
    public ParticleSystem Enginel;
    public ParticleSystem Enginer;
    public int ShellsActive;

    //Input keys vars//
    public string Up;
    public string Left;
    public string Right;
    public string Down;
    public string Shoot;
    ///////////////////

    public float lastFired;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject TmpShell;

        //Look towards cursor//
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        Vector2 FaceTo = new Vector2(cursorPosition.x - transform.position.x, cursorPosition.y - transform.position.y);
        TurretObj.transform.right = FaceTo;
        ///////////////////////

        //Input keys//
        if (Input.GetKey(Up))
        {
            TankRigid.transform.Translate(new Vector3(4f, 0f, 0f) * Time.deltaTime * 1);
            Enginer.Play();
            Enginel.Play();
        } else {
            Enginer.Stop();
            Enginel.Stop();
        }

        if (Input.GetKey(Down))
        {
            TankRigid.transform.Translate(new Vector3(-4f, -0f, 0f) * Time.deltaTime * 1);
        }
        if (Input.GetKey(Left))
        {
            TankRigid.transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime * 1);
        }
        if (Input.GetKey(Right))
        {
            TankRigid.transform.Rotate(new Vector3(0f, 0f, -200f) * Time.deltaTime * 1);

        }

        if (Input.GetKey(Shoot))
        {
            ShellsActive = GameObject.FindGameObjectsWithTag("PlayerShell").Length;
            if (Time.time > lastFired + 0.4f & ShellsActive < 3)
            {
                 TmpShell = Instantiate(Shell, TurretObj.transform.position + (TurretObj.transform.right * 1.2f), TurretObj.transform.rotation * Quaternion.Euler(0f, 0f, -90f));
                 lastFired = Time.time;
            }
        }
        //////////////
    }
}
