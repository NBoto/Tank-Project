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
    public AudioSource EngineSFX;
    public AudioSource FireSFX;
    public BackgroundMusicScript sm;
    public int ShellsActive;

    //Input keys vars//
    public string Up;
    public string Left;
    public string Right;
    public string Down;
    //public string Shoot;
    ///////////////////

    public float lastFired;


    // Update is called once per frame
    void Update()
    {
        /////////
        ///Grabs the sound manager and applies it's logic here. Since for some reason the link between the audio sources for the tank aren't working.
        if (!sm)
        {
            sm = GameObject.Find("SoundCompliance").GetComponent<BackgroundMusicScript>();
        }

        EngineSFX.volume = sm.PlayerEngine.volume;
        FireSFX.volume = sm.PlayerFire.volume;
        /////////

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
            if (!EngineSFX.isPlaying)
            {
                EngineSFX.Play();
            }
        }
        else
        if(Input.GetKey(Down))
        {
            TankRigid.transform.Translate(new Vector3(-4f, -0f, 0f) * Time.deltaTime * 1);
            if (!EngineSFX.isPlaying)
            {
                EngineSFX.Play();
            }
        }
        else {
            Enginer.Stop();
            Enginel.Stop();
            if (EngineSFX.isPlaying)
            {
                EngineSFX.Stop();
            }
        }
        if (Input.GetKey(Left))
        {
            TankRigid.transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime * 1);
        }
        if (Input.GetKey(Right))
        {
            TankRigid.transform.Rotate(new Vector3(0f, 0f, -200f) * Time.deltaTime * 1);

        }

        //if (Input.GetKey(Shoot))
        if (Input.GetMouseButtonDown(0))
        {
            ShellsActive = GameObject.FindGameObjectsWithTag("PlayerShell").Length;
            if (Time.time > lastFired + 0.4f & ShellsActive < 5)
            {
                 FireSFX.Play();
                 TmpShell = Instantiate(Shell, TurretObj.transform.position + (TurretObj.transform.right * 1.2f), TurretObj.transform.rotation * Quaternion.Euler(0f, 0f, -90f));
                 lastFired = Time.time;
            }
        }
        //////////////
    }
}
