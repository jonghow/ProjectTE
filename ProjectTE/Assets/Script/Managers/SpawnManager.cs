using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class SpawnManager
{
    public static SpawnManager Instance;
    public static SpawnManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new SpawnManager();
        }
        return Instance;
    }

    private CancellationTokenSource _cancellationToken;
    public void SpawnEntity(int _idx)
    {
        ClearUnitaskToken();
        _ = UTask_Spawn(_idx);
    }

    private void ClearUnitaskToken()
    {
        if(_cancellationToken != null)
        {
            _cancellationToken.Cancel();
            _cancellationToken.Dispose();
            _cancellationToken = null;
        }
    }

    async UniTask<GameObject> UTask_Spawn(int _idx)
    {
        // 데이터를 찾고
        string _spawnEntity = "Entity"; // 더미 데이터
        //PathManager.GetInstance().assetPath_Prefab

        UnityEngine.Object _obj = null;
        ResourceManager.Instance.GetResource(ResourceType.Entity, true, (loadedObject) =>
        {
            _obj = loadedObject;
        });

        await UniTask.WaitUntil(() =>  _obj != null);

        GameObject spawnedObject = _obj as GameObject;
        return spawnedObject;
    }
}