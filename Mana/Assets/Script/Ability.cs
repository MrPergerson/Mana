using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected bool isActive;
    [SerializeField] private float _manaCost = 0f;


    public float ManaCost
    {
        get { return _manaCost; }
        protected set { _manaCost = value; }
    }

    public abstract void Cast();

    public abstract void Stop();
}
