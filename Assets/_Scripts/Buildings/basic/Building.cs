using FirUnityEditor;
using System;
using UnityEngine;
using Zenject;

public abstract class Building : MonoBehaviour
{
    [Inject]
    protected BattleBalance battleBalance;
    [Inject]
    protected BattleManager battleManager;
    [SerializeField]
    private float currentHealth;
    [field: SerializeField, NullCheck]
    public Transform Entrance { get; private set; }
    public bool IsAlive => currentHealth > 0;

    public float Distance()
    {
        return Vector3.Distance(Entrance.position, owner.CastlePosition);
    }

    protected Player owner;

    public virtual void Initialize(Player player)
    {
        if (owner != null)
            throw new Exception("You cannot initialize an already initialized unit!");

        owner = player;
    }

    public virtual void TakeHit()
    {

    }
}
