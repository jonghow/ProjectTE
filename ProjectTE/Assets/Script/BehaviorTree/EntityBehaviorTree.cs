using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityBehaviorTree
{
    public enum BTNodeState
    {
        Success,
        Failure,
        Running
    }

    public interface IBehaviorTreeSetter
    {
        void AISetup();
    }

    public  class EntityBehaviorTreeBase 
    {
        string _name;
        int _uniqueID;
        protected EntityBehaviorTreeSelectorNode _root;
        protected EntityContoller _controller;

        public EntityBehaviorTreeBase(string _name, int _uniqueID, EntityContoller _controller)
        {
            this._name = _name;
            this._uniqueID = _uniqueID;
            this._controller = _controller;
        }
    }

    public class EntityBehaviorTreeNormalMonster : EntityBehaviorTreeBase , IBehaviorTreeSetter
    {
        public EntityBehaviorTreeNormalMonster(string _name, int _uniqueID, EntityContoller _controller) : base(_name, _uniqueID,_controller) {
            AISetup();
        }

        public virtual void AISetup()
        {
            _root = new EntityBehaviorTreeSelectorNode();

            EntityBehaviorTreeSequenceNode detectRangeSequence = new EntityBehaviorTreeSequenceNode();

            EntityBehaviorTreeConditionNode detectRangeCondition = new EntityBehaviorTreeConditionNode(new ConditionDetectRangeStategy(_controller.transform, _controller._target, 5f));
            EntityBehaviorTreeActionNode detectRangeProbe = new EntityBehaviorTreeActionNode(new MonsterProbe(_controller.transform));

            EntityBehaviorTreeSequenceNode atkSequence = new EntityBehaviorTreeSequenceNode();
            EntityBehaviorTreeConditionNode atkPreDelayAction = new EntityBehaviorTreeConditionNode(new ConditionAtkPreDelayStrategy(2f)); // Áö±ÝÀº ¼±µô
            EntityBehaviorTreeActionNode atkAction = new EntityBehaviorTreeActionNode(new NormalAtkStrategy(_controller.transform, _controller._target));

            EntityBehaviorTreeSequenceNode chaseSequence = new EntityBehaviorTreeSequenceNode();
            EntityBehaviorTreeConditionNode playerInRange = new EntityBehaviorTreeConditionNode(new ConditionRangeStrategy(_controller.transform, _controller._target, 2f));
            EntityBehaviorTreeActionNode chaseAction = new EntityBehaviorTreeActionNode(new ChaseStrategy(_controller.transform, _controller._target));


            _root.AddChild(detectRangeSequence);
            _root.AddChild(atkSequence);
            _root.AddChild(chaseSequence);

            detectRangeSequence.AddChild(detectRangeCondition);
            detectRangeSequence.AddChild(detectRangeProbe);

            atkSequence.AddChild(atkPreDelayAction);
            atkSequence.AddChild(atkAction);

            chaseSequence.AddChild(playerInRange);
            chaseSequence.AddChild(chaseAction);
        }

        public void Evaluate()
        {
            this._root.Evaluate();
        }
    }
}


