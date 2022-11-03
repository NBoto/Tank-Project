using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : MonoBehaviour
{

    // Assistance/Referance used:
    // Tank Tutorial: https://www.youtube.com/watch?v=monYp9VlBy4&t=1s
    public Rigidbody2D rb2d;
    private Vector2 movementVector;
    public GameObject Shell;
    public GameObject TurretEndPoint;
    public float maxSpeed = 30;
    public float rotationSpeed = 100;
    public float turretRotationSpeed = 100;
    public float lastFired;

    public Transform turretParent;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void HandleShoot()
    {
        GameObject tmpShell;
        if (Time.time > lastFired + 0.3f)
        {
            Debug.Log("Shooting");
            var FixAngle = Quaternion.Euler(0, 0, -90);
            tmpShell = Instantiate(Shell, TurretEndPoint.transform.position + (TurretEndPoint.transform.right * 0.7f), TurretEndPoint.transform.rotation * FixAngle);
            lastFired = Time.time;
        }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;

        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;

        var rotationStep = turretRotationSpeed * Time.deltaTime;

        turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, Quaternion.Euler(0, 0, desiredAngle), rotationStep);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }
}
