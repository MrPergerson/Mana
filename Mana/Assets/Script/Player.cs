using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SimpleMove))]
public class Player : Actor
{
    Controls controls;

    SimpleMove move;
    [SerializeField] float mana = 0;
    [SerializeField] int heath = 5;
    [SerializeField] bool _isInvicible;

    [SerializeField] Ability currentAbility;

    private float invicibleTime = .5f;
    private float timeSinceInvicible = 0;

    public UnityEvent onDeath;
    public UnityEvent<float> onHeathChange;
    public UnityEvent<float> onManaChange;

    protected bool isCasting = false;

    public bool IsInvicible
    {
        get { return _isInvicible; }
        set { _isInvicible = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        move = GetComponent<SimpleMove>();
        controls = new Controls();

        controls.Player.CastSpell.performed += ctx => { currentAbility.Cast(); isCasting = true;};
        controls.Player.CastSpell.canceled += ctx => { currentAbility.Stop(); isCasting = false; };

        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    protected override void Start()
    {
        onHeathChange.Invoke(heath);
        onManaChange.Invoke(mana);
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

        if (Time.time - timeSinceInvicible > invicibleTime)
        {
            IsInvicible = false;
        }

        if (isCasting)
        {
            mana -= (currentAbility.ManaCost * Time.deltaTime);
            onManaChange.Invoke(mana);
        }
    }

    public void Damage(float damage)
    {
        if(IsInvicible == false)
        {
            StartCoroutine(base.Flash(invicibleTime));
            heath -= 1;
            onHeathChange.Invoke(heath);
            IsInvicible = true;
            timeSinceInvicible = Time.time;

            if (heath <= 0)
                onDeath.Invoke();
        }
    }

    public void CollectMana(float count)
    {
        mana += count;
        onManaChange.Invoke(mana);
    }
}
