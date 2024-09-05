using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EntityBehaviorTree
{
    public interface BTConditionStrategy
    {
        public BTNodeState Check();
        public void Reset();
    }

    public class ConditionDetectRangeStategy : EntityBehaviorTreeNodeBase, BTConditionStrategy
    {
        private Transform _owner;
        private Transform _target;
        private float _detectRange;

        public ConditionDetectRangeStategy(Transform _owner, Transform _target, float _detectRange)
        {
            this._owner = _owner;
            this._target = _target;
            this._detectRange = _detectRange;
        }

        public BTNodeState Check()
        {
            return Vector3.Distance(_owner.position , _target.position) >= _detectRange ? BTNodeState.Success : BTNodeState.Failure;
        }

        public void Reset()
        {
        }
    }

    public class ConditionRangeStrategy : EntityBehaviorTreeNodeBase, BTConditionStrategy
    {
        private Transform _owner;
        private Transform _target;

        private float _attackRange;

        public ConditionRangeStrategy(Transform _owner, Transform _target, float _attackRange)
        {
            this._owner = _owner;
            this._target = _target;
            this._attackRange = _attackRange;
        }
        public BTNodeState Check()
        {
            return Vector3.Distance(_owner.position ,_target.position) >= _attackRange ? BTNodeState.Success : BTNodeState.Failure;
        }

        public void Reset()
        {
        }
    }

    public class ConditionAtkPreDelayStrategy : EntityBehaviorTreeNodeBase, BTConditionStrategy
    {
        // 공격 후딜레이, 기다리는 시간
        float _waitDelay;
        float _accumulationDelay;
        public ConditionAtkPreDelayStrategy(float _delay)
        {
            this._waitDelay = _delay;
            this._accumulationDelay = 0f;
        }
        public BTNodeState Check()
        {
            BTNodeState eState = BTNodeState.Success;
            if (CheckDelayTime())
            {
                Reset();
                eState = BTNodeState.Success;
            }
            else
            {
                AddTime();
                eState = BTNodeState.Failure;
            }

            return eState;
        }

        public bool CheckDelayTime()
        {
            if (_waitDelay >= _accumulationDelay)
                return false;

            return true;
        }

        private void AddTime()
        {
            _accumulationDelay += Time.deltaTime;
        }

        public void Reset()
        {
            this._accumulationDelay = 0f;
        }
    }










    public class EntityBehaviorTreeConditionNode : EntityBehaviorTreeNodeBase
    {
        BTConditionStrategy _strategy;
        public EntityBehaviorTreeConditionNode(BTConditionStrategy _strategy)
        {
            this._strategy = _strategy;
        }
        public override BTNodeState Evaluate()
        {
            return _strategy.Check();
        }

        public void Reset()
        {
        }
    }
}


