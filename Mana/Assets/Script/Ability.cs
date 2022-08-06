using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected bool isActive;

    public abstract void Cast();

    public abstract void Stop();
}
