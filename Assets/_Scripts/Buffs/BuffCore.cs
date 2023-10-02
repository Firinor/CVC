using UnityEngine;

namespace Buffs
{
    public abstract class BuffCore : ScriptableObject
    {
        public int Duration;
        public virtual void OnStart(BasicUnit unit) { }
        public virtual void Tick(BasicUnit unit) { }
        public virtual void OnEnd(BasicUnit unit) { }
        public virtual void Decorate(AttackData attackData) { }
    }
}
