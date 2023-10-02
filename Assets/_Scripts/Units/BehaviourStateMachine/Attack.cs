using UnityEngine;

namespace UnitBehaviourNamespace
{
    [CreateAssetMenu(fileName = "AttackUnitBehavior", menuName = "GameScriptable/UnitBehaviors/EnemyAttackBehavior")]
    public class Attack : UnitBehaviour<BasicUnit>
    {
        [Header("Behavior transitions")]
        [SerializeField]
        private UnitBehaviour<BasicUnit> idle;
        [SerializeField]
        private UnitBehaviour<BasicUnit> move;

        public override void Tick(BasicUnit unit)
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

