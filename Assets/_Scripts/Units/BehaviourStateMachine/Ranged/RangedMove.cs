using UnityEngine;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "RangedMove", menuName = "GameScriptable/UnitBehaviors/RangedMove")]
    public class RangedMove : UnitBehaviour<Unit>
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private UnitBehaviour<Unit> attack;
        [SerializeField]
        private UnitBehaviour<Unit> idle;

        public override void Tick(Unit unit)
        {
            if (!unit.IsOwnerAlive)
            {
                unit.SetBehavior(idle);
                return;
            }

            if (unit.IsEnemyInRange())
            {
                unit.SetBehavior(attack);
                return;
            }

            unit.NavMeshAgent.SetDestination(unit.Target);
        }

        public override void Exit(Unit unit)
        {
            unit.NavMeshAgent.SetDestination(unit.transform.position);
        }
    }
}