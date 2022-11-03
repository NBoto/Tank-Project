using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{

    private Rigidbody2D ShellRigid;

    // Use this for initialization
    void Start()
    {
        ShellRigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
;
        ShellRigid.AddForce(this.transform.up * 8);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            Vector2 EnvironmentNorm = collision.contacts[0].normal;
            Vector2 ReflectDir = Vector2.Reflect(ShellRigid.velocity, EnvironmentNorm).normalized;

            ShellRigid.velocity = ReflectDir * this.transform.up * 8;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}


