using UnityEngine;
using Zenject;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "IdleUnitBehavior", menuName = "GameScriptable/UnitBehaviors/IdleUnitBehavior")]
    public class Idle : UnitBehaviour<Unit>
    {
    }
}