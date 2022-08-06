using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Chase))]
public class Enemy : Actor
{
    [SerializeField] private int damage = 1;
    [SerializeField] private Transform _target;
    [SerializeField] private bool _isDisabled;


    [SerializeField] private float disabledTime = 1.5f;
    private float timeSinceDisabled;

    private Chase chase; // would like this to not be a requirement in the future

    public Transform Target { get { return _target; } set { _target = value; } }

    public bool IsDisabled
    {
        get
        {
            return _isDisabled;
        }
        set
        {
            _isDisabled = value;

            if (_isDisabled)
            {
                timeSinceDisabled = Time.time;
                chase.enabled = false;
            }
            else
            {
                chase.enabled = true;
            }

        }
    }
    

    protected override void Awake()
    {
        base.Awake();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        chase = GetComponent<Chase>();

    }

    private void Update()
    {
        if(Time.time - timeSinceDisabled > disabledTime)
        {
            IsDisabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.transform.tag == "Player")
        {
            var player = collision.transform.GetComponent<Player>();
            player.Damage(damage);
        }
    }

    public void Damage(float damage, Vector2 knockback)
    {
        IsDisabled = true;
        StartCoroutine(base.Flash(disabledTime));
        rb.AddForce(knockback, ForceMode2D.Impulse);
    }
}
