using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviorTree;

public abstract class EntityContoller : MonoBehaviour
{
    public Transform _target;
    protected abstract void SetUp();
}

public class EntityPlayerContoller : EntityContoller
{
    protected override void SetUp()
    {
        throw new System.NotImplementedException();
    }
}

public interface BehaviorTreeAI
{

}
