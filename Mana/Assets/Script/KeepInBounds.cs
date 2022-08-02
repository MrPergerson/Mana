using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class KeepInBounds : MonoBehaviour
{
    Actor actor;

    [SerializeField] bool bounce;
    [SerializeField] float bounceForce = 1;

    private void Awake()
    {
        actor = GetComponent<Actor>();
    }

    private void LateUpdate()
    {
        var newVelocity = actor.rb.velocity;
        var newPosition = actor.rb.position;

        if (newPosition.x < LevelBounds.AdjustedBounds.xMin)
        {
            newPosition.x = LevelBounds.AdjustedBounds.xMin;
            if (bounce)
                newVelocity.x = -newVelocity.x * bounceForce;
            else
                newVelocity.x = 0;
        }
        else if (newPosition.x > LevelBounds.AdjustedBounds.xMax)
        {
            newPosition.x = LevelBounds.AdjustedBounds.xMax;
            if (bounce)
                newVelocity.x = -newVelocity.x * bounceForce;
            else
                newVelocity.x = 0;
        }
        if (newPosition.y < LevelBounds.AdjustedBounds.yMin)
        {
            newPosition.y = LevelBounds.AdjustedBounds.yMin;
            if (bounce)
                newVelocity.y = -newVelocity.y * bounceForce;
            else
                newVelocity.y = 0;
        }
        else if (newPosition.y > LevelBounds.AdjustedBounds.yMax)
        {
            newPosition.y = LevelBounds.AdjustedBounds.yMax;
            if (bounce)
                newVelocity.y = -newVelocity.y * bounceForce;
            else
                newVelocity.y = 0;
        }

        actor.transform.position = newPosition;
        actor.rb.velocity = newVelocity;
    }
}
