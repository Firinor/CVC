using UnityEngine;

namespace UnitBehaviourNamespace
{
    [CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/Move")]
    public class Move : UnitBehaviour<BasicUnit>
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private UnitBehaviour<BasicUnit> idle;

        public override void Tick(BasicUnit unit)
        {
            if (!unit.IsOwnerAlive)
            {
                unit.SetBehavior(idle);
                return;
            }


            unit.NavMeshAgent.SetDestination(unit.Target);
        }
    }
}