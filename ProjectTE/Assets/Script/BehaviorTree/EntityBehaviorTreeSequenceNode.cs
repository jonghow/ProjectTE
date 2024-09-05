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
                    return BTNodeState.Failure; // 실패한 경우 즉시 반환
                }
                else if (ret == BTNodeState.Running)
                {
                    childRunning = true; // 실행 중인 노드가 있으면 실행 중 상태 반환
                }
            }

            return childRunning ? BTNodeState.Running : BTNodeState.Success;
        }

        public void Dispose()
        {
        }
    }
}


