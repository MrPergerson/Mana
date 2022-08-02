using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMove : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] float moveSpeed = 3f;
    [SerializeField, Range(0f, 20f)] float maxAcceleration = 10f;
    [SerializeField] bool _strictDirection = true;
    Rigidbody2D rb;

    Vector2 direction;
    Vector2 testdirection;
    Vector2 velocity;
    Vector2 previousPosition;
    Camera cam;

    bool moveInitialized;

    public bool StrictDirection 
    { 
        get { return _strictDirection; }
        set { _strictDirection = value; }
    }
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if(!StrictDirection)
        {
            Vector2 heading = (Vector2) transform.position - previousPosition;
            //print("LateUpdate: " + heading);
            direction = heading.normalized;
        }
    }




    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        velocity = rb.velocity;
        previousPosition = transform.position;

        Vector2 desiredVelocity = direction * moveSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);

        rb.velocity = velocity;
        //moveInitialized = true;


    }

    public void MoveToDirection(Vector2 direction)
    {
        this.direction = direction;
        this.direction.Normalize();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine((Vector2) transform.position, (Vector2) transform.position + direction);
    }
}
