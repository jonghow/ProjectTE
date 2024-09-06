using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviorTree;

public abstract class EntityContoller : MonoBehaviour
{
    public Transform _target;
    public AnimationPlayer _animPlayer;
    public EntityCategory _category;

    protected abstract void SetUp();
}
