using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{

    private Rigidbody2D ShellRigid;
    private int ShellLife;
    public AudioSource RicochetSFX;
    private GameStateManager gsm;
    public GameObject ExplosionP;
    public AudioSource ExplosionSFX;

    // Use this for initialization
    void Start()
    {
        ShellRigid = this.GetComponent<Rigidbody2D>();
        ShellRigid.transform.localScale = (new Vector3(0.1f, 0.1f, 0.1f));
        //ShellRigid.AddForce(this.transform.up * 1350);
        gsm = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.Paused) {
        ShellLife++;
        if (ShellLife >= 4250)
        {
            Destroy(this.gameObject);
            }

            ShellRigid.AddForce(this.transform.up * 40);
            //ShellRigid.transform.Translate(new Vector3(0f, 0.007f, 0f));
            ShellRigid.transform.localScale -= (new Vector3(0.00001f, 0.00001f, 0.00001f));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Explosion;

        if (collision.gameObject.tag == "Environment")
        {
            if (ShellLife <= 20)
            {
                Destroy(this.gameObject);
            }else
            {
                RicochetSFX.Play();
            }
            // https://forum.unity.com/threads/2d-ricochet-solved.501723/ <- Code Ref location v
            Vector3 v = Vector2.Reflect(transform.right, collision.contacts[0].normal);
            float rot = Random.Range(-120, -200) - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, rot);
            // ^
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            Explosion = Instantiate(ExplosionP, this.transform.position, this.transform.rotation);
            ExplosionSFX.Play();
        }
        if (collision.gameObject.tag == "PlayerShell")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            Explosion = Instantiate(ExplosionP, this.transform.position, this.transform.rotation);
            ExplosionSFX.Play();
        }
        if (collision.gameObject.tag == "EnemyDecoy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gsm.adjustScore(5);

            Explosion = Instantiate(ExplosionP, this.transform.position, this.transform.rotation);
            ExplosionSFX.Play();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gsm.adjustScore(5);

            Explosion = Instantiate(ExplosionP, this.transform.position, this.transform.rotation);
            ExplosionSFX.Play();
        }
        if (collision.gameObject.tag == "EnemyShell")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gsm.adjustScore(1);

            Explosion = Instantiate(ExplosionP, this.transform.position, this.transform.rotation);
            ExplosionSFX.Play();
        }
    }
}


