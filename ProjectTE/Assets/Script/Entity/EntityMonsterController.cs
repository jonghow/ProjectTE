using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviorTree;




public class EntityMonsterController : EntityContoller
{
   private float _detectRange;
    private float _attackRange;
    private float _moveSpeed;

    // 월드 모델은 어디서 관리?
    private Avatar _avatar; // 공용화된 모델 베이스
    private EntityBehaviorTreeNormalMonster _behaviorTree;

    // Controller BuffSystem
    private AbnormalSystem _abnormalSystem;


    public void Start()
    {
        SetUp();
    }
    protected override void SetUp()
    { 
        AISetUp();
        AbnormalSystemSetUp();

        _detectRange = 5.0f;
        _attackRange = 1.5f;
        _moveSpeed = 2.5f;
    }
    private void AISetUp()
    {
        _behaviorTree = new EntityBehaviorTreeNormalMonster($"Monster", 1, this);
        _behaviorTree.Evaluate();
    }

    private void AbnormalSystemSetUp()
    {
        _abnormalSystem = new AbnormalSystem();
    }

    private void Update()
    {
        // AI 평가
        _behaviorTree.Evaluate();

        // Abnormal
        float smoothDeltaTime = Time.smoothDeltaTime;
        _abnormalSystem.OnUpdateAbnormals(smoothDeltaTime);
    }

    public void OnDrawGizmos()
    {
        Color color = Color.blue;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, _attackRange);

        color = Color.magenta;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, _detectRange);
    }
}
