using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStage : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // ���� �ڸ����� �츮���� ������Ʈ ����
            Debug.Log($"[BattleStage] Update, Push R");

            var spawner = new UserEntityFactory();
            spawner.CreateEntity();
            
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            // ���� �ڸ����� ����� ������Ʈ ����
            Debug.Log($"[BattleStage] Update, Push T");

            var spawner = new RivalEntityFactory();
            spawner.CreateEntity();
        }
    }
}
