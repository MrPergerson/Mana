using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SimpleMove))]
public class Player : Actor
{
    Controls controls;

    SimpleMove move;
    [SerializeField] float _mana = 0;
    [SerializeField] int _heath = 0;
    [SerializeField] bool _isInvicible;

    [SerializeField] Ability currentAbility;

    private float invicibleTime = .5f;
    private float timeSinceInvicible = 0;

    public UnityEvent onDeath;

    protected bool isCasting = false;

    private bool characterMenuOpened = false;
    [SerializeField] GameObject characterMenu;

    private bool gamePaused = false;

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
        controls.Player.CharacterMenu.performed += ctx => ToggleCharacterMenu();

        if (onDeath == null)
            onDeath = new UnityEvent();
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
            CharacterStats.Mana -= (currentAbility.ManaCost * Time.deltaTime);
        }

        _heath = CharacterStats.Health;
        _mana = CharacterStats.Mana;
    }

    public void Damage(float damage)
    {
        if(IsInvicible == false)
        {
            StartCoroutine(base.Flash(invicibleTime));
            CharacterStats.Health -= 1;
            IsInvicible = true;
            timeSinceInvicible = Time.time;

            if (CharacterStats.Health <= 0)
                onDeath.Invoke();
        }
    }

    public void CollectMana(float count)
    {
        CharacterStats.Mana += count;
    }

    private void ToggleCharacterMenu()
    {
        characterMenuOpened = !characterMenuOpened;
        
        
        if(characterMenu)
        {
            if(characterMenuOpened)
            {
                characterMenu.SetActive(true);
                PauseGame();
            }
            else
            {
                characterMenu.SetActive(false);
                ResumeGame();
            }

        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
