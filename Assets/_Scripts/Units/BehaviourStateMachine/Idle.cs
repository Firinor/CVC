using UnityEngine;
using Zenject;

namespace UnitBehaviourNamespace
{
    [CreateAssetMenu(fileName = "IdleUnitBehavior", menuName = "GameScriptable/UnitBehaviors/IdleUnitBehavior")]
    public class Idle : UnitBehaviour<BasicUnit>
    {
    }
}