using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityBehaviorTree;

public class BattleRoutine : MonoBehaviour
{
    // 고정데미지 프로그레서
    // 연산데미지 프로그레서

    /* 
     * 데미지 연산의 순서, 
     * 1. 절대 방어 ( 횟수 방어 ) 
     * 2. 쉴드 게이지 ( 쉴드 게이지 )
     * 3. 체력 
    */

    public void OnUpdateBattleRoutine(long shooterID, long _effectorID)
    {



    }
}

