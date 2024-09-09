using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviorTree;

public class EntityUserContoller : EntityContoller
{
    private float _detectRange;
    private float _attackRange;
    private float _moveSpeed;

    // ���� ���� ��� ����?
    private Avatar _avatar; // ����ȭ�� �� ���̽�
    private EntityBehaviorTreeNormalMonster _behaviorTree;

    public void Start()
    {
        SetUp();
    }

    protected override void SetUp()
    {
        AISetUp();

        _detectRange = 5.0f;
        _attackRange = 1.5f;
        _moveSpeed = 2.5f;
    }

    private void AISetUp()
    {
        _behaviorTree = new EntityBehaviorTreeNormalMonster($"Monster", 1, this);
        _behaviorTree.Evaluate();
    }

    private void Update()
    {
        // AI ��
        _behaviorTree.Evaluate();
    }

    public void OnDrawGizmos()
    {
        Color color = Color.green;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, _attackRange);

        color = Color.gray;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, _detectRange);
    }
}
