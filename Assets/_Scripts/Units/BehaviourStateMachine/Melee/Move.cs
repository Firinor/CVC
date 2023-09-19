using UnityEngine;

namespace UnitBehaviourNamespace
{
    [CreateAssetMenu(fileName = "MoveUnitBehavior", menuName = "GameScriptable/UnitBehaviors/Move")]
    public class Move : UnitBehaviour<Unit>
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private UnitBehaviour<Unit> idle;

        public override void Tick(Unit unit)
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