using UnityEngine;
using Zenject;

namespace UnitBehaviourNamespace
{
    [CreateAssetMenu(fileName = "Idle", menuName = "GameScriptable/UnitBehaviors/IdleUnitBehavior")]
    public class Idle : UnitBehaviour<BasicUnit>
    {
    }
}