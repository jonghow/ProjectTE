using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EntityBehaviorTree
{
    public class EntityBehaviorTreeSelectorNode : EntityBehaviorTreeNodeBase, IDisposable
    {
        public override BTNodeState Evaluate()
        {
            for (int i = 0; i < child.Count; ++i)
            {
                var node = child[i];
                if (node == null) continue;

                BTNodeState ret = node.Evaluate();
                switch (ret)
                {
                    case BTNodeState.Success:
                        return BTNodeState.Success;
                    case BTNodeState.Running:
                        return BTNodeState.Running;
                    case BTNodeState.Failure:
                        continue;
                    default:
                        break;
                }
            }

            return BTNodeState.Failure;
        }

        public void Dispose()
        {
        }
    }
}


