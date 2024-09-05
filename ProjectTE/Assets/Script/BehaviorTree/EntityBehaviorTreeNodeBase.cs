using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityBehaviorTree
{
    public interface IEntityBehaviorNodeBaseFunc
    {
        public void AddChild(EntityBehaviorTreeNodeBase node);
        public BTNodeState Evaluate();
    }

    public abstract class EntityBehaviorTreeNodeBase : IEntityBehaviorNodeBaseFunc
    {
        protected string _name;
        protected List<EntityBehaviorTreeNodeBase> child = new List<EntityBehaviorTreeNodeBase>();

        public void AddChild(EntityBehaviorTreeNodeBase node)
        {
            if (child == null)
                child = new List<EntityBehaviorTreeNodeBase>();

            child.Add(node);
        }

        public virtual BTNodeState Evaluate()
        {
            return BTNodeState.Failure;
        }
    }
}


