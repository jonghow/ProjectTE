using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BattleStage : MonoBehaviour
{
    float a = 0f;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // 현재 자리에서 우리팀의 오브젝트 생성
            UnityEngine.Debug.Log($"[BattleStage] Update, Push R");

            var spawner = new UserEntityFactory();
            spawner.CreateEntity();
            
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            // 현재 자리에서 상대팀 오브젝트 생성
            UnityEngine.Debug.Log($"[BattleStage] Update, Push T");

            var spawner = new RivalEntityFactory();
            spawner.CreateEntity();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            UnityEngine.Debug.Log($"[BattleStage] Update, Push Q");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ResourceManager.GetInstance().UTaskGetResource(AssetBundleType.ModelCharacter ,ResourceType.Effect, $"Effect", true, (ret) =>
            {
                ++a;

                sw.Stop();
                UnityEngine.Debug.Log($"[BattleStage] Load Complete time : {sw.ElapsedMilliseconds}");

                GameObject obj = GameObject.Instantiate(ret) as GameObject;
                obj.transform.position = new Vector3(a, 0f, a);
            });
        }
    }
}
