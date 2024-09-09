using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStage : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // 현재 자리에서 우리팀의 오브젝트 생성
            Debug.Log($"[BattleStage] Update, Push R");

            var spawner = new UserEntityFactory();
            spawner.CreateEntity();
            
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            // 현재 자리에서 상대팀 오브젝트 생성
            Debug.Log($"[BattleStage] Update, Push T");

            var spawner = new RivalEntityFactory();
            spawner.CreateEntity();
        }
    }
}
