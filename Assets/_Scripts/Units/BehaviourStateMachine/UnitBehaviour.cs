using UnityEngine;

public class UnitBehaviour<TUnit> : ScriptableObject where TUnit : BasicUnit
{ 
    public virtual void Enter(TUnit unit) { }
    public virtual void Tick(TUnit unit) { }
    public virtual void Exit(TUnit unit) { }
}