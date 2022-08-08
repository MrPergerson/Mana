using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CharacterStats
{
    private static int _health = 5;
    private static int _maxHealth = 5;
    private static float _speed;
    private static float _mana = 0;
    private static float _manaMultiplier = 1;

    public delegate void HealthChange();
    public static event HealthChange onHealthChange;

    public delegate void MaxHealthChange();
    public static event MaxHealthChange onMaxHealthChange;

    public delegate void ManaChange();
    public static event ManaChange onManaChange;


    public static int Health
    {
        get { return _health; }
        set { _health = value; onHealthChange?.Invoke(); }
    }

    public static int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; onMaxHealthChange?.Invoke(); }
    }


    public static float Mana
    {
        get { return _mana; }
        set { _mana = value; onManaChange?.Invoke(); }
    }

    public static float ManaMultiplier
    {
        get { return _manaMultiplier; }
        set { _manaMultiplier = value; }
    }
}
