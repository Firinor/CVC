using UnityEngine;

namespace UnitBehaviourNamespace
{
    [CreateAssetMenu(fileName = "AttackUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyAttackBehavior")]
    public class Attack : UnitBehaviour<Unit>
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private UnitBehaviour<Unit> idle;
        [SerializeField]
        private UnitBehaviour<Unit> move;

        public override void Tick(Unit unit)
        {
            //if (!unit.IsPlayerInSight())
            //{
            //    unit.SetBehavior(move);
            //    return;
            //}
                

            if (!unit.IsEnemyAlive)
            {
                unit.SetBehavior(idle);
                return;
            }

            //unit.LookAtPlayer();
            unit.Attack();
        }
    }
}

