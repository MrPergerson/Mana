using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SimpleMove))]
public class Player : Actor
{
    Controls controls;

    SimpleMove move;

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<SimpleMove>();
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    protected override void Update()
    {
        base.Update();
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();
        move.MoveToDirection(moveInput);
    }
}
