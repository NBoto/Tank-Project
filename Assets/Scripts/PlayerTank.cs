using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTank : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public UnityEvent OnPlayerShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();

    // Update is called once per frame
    void Update()
    {
        GetBodyMovement();
        GetTurretAngle();
        GetPlayerShoot();

    }

    private void GetPlayerShoot() // Player shoot event.
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnPlayerShoot?.Invoke();
        }
    }

    private void GetTurretAngle() // Player tank turret angle event.
    {
        OnMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition() // Player mouse position on screen event.
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetBodyMovement() // Player tank movement event.
    {
        Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
}
