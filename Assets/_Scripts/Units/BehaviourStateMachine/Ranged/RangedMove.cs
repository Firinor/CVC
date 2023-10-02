using UnityEngine;

namespace EnemyBehaviourNamespace
{
    [CreateAssetMenu(fileName = "RangedMove", menuName = "GameScriptable/UnitBehaviors/RangedMove")]
    public class RangedMove : UnitBehaviour<BasicUnit>
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private UnitBehaviour<BasicUnit> attack;
        [SerializeField]
        private UnitBehaviour<BasicUnit> idle;

        public override void Tick(BasicUnit unit)
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

        public override void Exit(BasicUnit unit)
        {
            unit.NavMeshAgent.SetDestination(unit.transform.position);
        }
    }
}