using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EntityBehaviorTree
{
    public interface BTActionStrategy
    {
        public BTNodeState Run();
        public void Reset();
    }
    public class ChaseStrategy : BTActionStrategy
    {
        private Transform _ownerTransform;
        public Transform _targetTransform;
        private float _moveSpeed;

        //public _aStarAgent; 
        //TODO:

        public ChaseStrategy(Transform _owner, Transform _target)
        {
            _ownerTransform = _owner;
            _targetTransform = _target;
            _moveSpeed = 3f;
        }

        public BTNodeState Run()
        {
            float dist = Vector3.Distance(_ownerTransform.position, _targetTransform.position);
            //Debug.Log($"Chase! Distance :: {dist}");
            _ownerTransform.position = Vector3.MoveTowards(_ownerTransform.position, _targetTransform.position, _moveSpeed * Time.deltaTime);
            _ownerTransform.LookAt(_targetTransform.position);
            return BTNodeState.Running;
        }

        public void Reset() { }
    }

    public class NormalAtkStrategy : BTActionStrategy
    {
        private Transform _shooter;
        public Transform _target;

        public NormalAtkStrategy(Transform _shooter, Transform _target)
        {
            // 평타는 보통 타겟을 정해서 발사한다.
            this._shooter = _shooter;
            this._target = _target;
        }
        public BTNodeState Run()
        {
            // Run
            Debug.Log($"Attack!! {_shooter.name} to {_target.name}");

            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            obj.transform.position = _shooter.position + _shooter.forward * 3f;

            return BTNodeState.Success;
        }

        public void Reset()
        {

        }
    }

    public class MonsterProbe : BTActionStrategy
    {
        private Transform _owner;
        private List<Vector3> _probeList;
        private int _currentIndex;
        private float _speed;

        public MonsterProbe(Transform _owner)
        {
            _currentIndex = 0;
            _speed = 5f;

            this._owner = _owner;

            if(_probeList == null )
                _probeList = new List<Vector3>();

            _probeList.Clear();

            for(int i = 0; i < 4; ++i)
            {
                int rangeX = UnityEngine.Random.Range(1, 15);
                int rangeZ = UnityEngine.Random.Range(1, 15);

                Vector3 pos = new Vector3(_owner.transform.position.x - rangeX, _owner.transform.position.y , _owner.transform.position.z - rangeZ);
                _probeList.Add(pos);
            }
        }
        public BTNodeState Run()
        {
            UpdatePosition();
            return BTNodeState.Success;
        }

        public void UpdatePosition()
        {
            if (_currentIndex >= _probeList.Count)
                _currentIndex = 0;

            Vector3 currentPos = _owner.position;
            Vector3 destinationPos = _probeList[_currentIndex];

            Vector3 dir = (destinationPos - currentPos).normalized;

            Vector3 P0 = _owner.position;
            Vector3 AT = dir * _speed * Time.deltaTime;
            Vector3 P1 = P0 + AT;
            _owner.position = P1;
            _owner.LookAt(destinationPos);

            if (Vector3.Distance(currentPos, destinationPos) <= 0.1f)
                ++_currentIndex;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }

    public class EntityBehaviorTreeActionNode : EntityBehaviorTreeNodeBase
    {
        BTActionStrategy _strategy;

        public EntityBehaviorTreeActionNode(BTActionStrategy _strategy)
        {
            this._strategy = _strategy;
        }

        public override BTNodeState Evaluate()
        {
            return _strategy.Run();
        }
    }
}


