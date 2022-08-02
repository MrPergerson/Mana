using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sandbox;

[RequireComponent(typeof(SimpleMove))]
public class Portal : Actor
{

    SimpleMove move;

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<SimpleMove>();
       
    }

    protected override void Start()
    {
        base.Start();
        SetInitialMoveDirection();
        move.StrictDirection = false;
    }

    public void SetInitialMoveDirection()
    {
        RandomMagic random = new RandomMagic();

        //move.MoveToDirection(random.GetRandomDirection2D());
        rb.AddForce(random.GetRandomDirection2D(), ForceMode2D.Impulse);
        

    }

}
