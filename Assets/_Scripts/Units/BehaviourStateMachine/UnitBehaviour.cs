using UnityEngine;

public abstract class UnitBehaviour<TUnit> : ScriptableObject where TUnit : Unit
{ 
    public virtual void Enter(TUnit unit) { }
    public virtual void Tick(TUnit unit) { }
    public virtual void Exit(TUnit unit) { }
}