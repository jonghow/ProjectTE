using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EntityBehaviorTree
{
    public class EntityBehaviorTreeSequenceNode : EntityBehaviorTreeNodeBase, IDisposable
    {
        public override BTNodeState Evaluate()
        {
            bool childRunning = false;

            for(int i = 0; i < child.Count; ++i)
            {
                var node = child[i];
                if (node == null) continue;

                BTNodeState ret = node.Evaluate();

                if (ret == BTNodeState.Failure)
                {
                    return BTNodeState.Failure; // ������ ��� ��� ��ȯ
                }
                else if (ret == BTNodeState.Running)
                {
                    childRunning = true; // ���� ���� ��尡 ������ ���� �� ���� ��ȯ
                }
            }

            return childRunning ? BTNodeState.Running : BTNodeState.Success;
        }

        public void Dispose()
        {
        }
    }
}


