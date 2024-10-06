using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class PoolingManager
{
    public static PoolingManager Instance;

    public static PoolingManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new PoolingManager();
            Instance.Init();
        }

        return Instance;
    }

    private Dictionary<PooledObject, Dictionary<PooledObject, GameObject>> _dicPoolObject = new Dictionary<PooledObject, Dictionary<PooledObject, GameObject>>();

    public void Init()
    {
        _dicPoolObject.Clear();
        InitCreatePoolObject().Forget();
    }

    private async UniTaskVoid InitCreatePoolObject()
    {
        //PathManager.GetInstance().assetPath_Prefab;
        UnityEngine.Object obj = null;
        bool isLoading = false;
        return;

        //// 풀 오브젝트 로딩 _ Entity
        //ResourceManager.GetInstance().UTaskGetResource(ResourceType.Entity, $"Entity" ,true, (ret) => 
        //{ 
        //    obj = ret;
        //    isLoading = true;
        //});
        //await UniTask.WaitUntil(() => isLoading == true);

        //// 풀 오브젝트 로딩 _ Projectile
        //isLoading = false;
        //ResourceManager.GetInstance().UTaskGetResource(ResourceType.Projectile, $"Projectile", true, (ret) =>
        //{
        //    obj = ret;
        //    isLoading = true;
        //});
        //await UniTask.WaitUntil(() => isLoading == true);

        //// 풀 오브젝트 로딩 _ Effect
        //isLoading = false;
        //ResourceManager.GetInstance().UTaskGetResource(ResourceType.Effect,$"Effect", true, (ret) =>
        //{
        //    obj = ret;
        //    isLoading = true;
        //});
        //await UniTask.WaitUntil(() => isLoading == true);
    }
}
