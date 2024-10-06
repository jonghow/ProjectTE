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

        //// Ǯ ������Ʈ �ε� _ Entity
        //ResourceManager.GetInstance().UTaskGetResource(ResourceType.Entity, $"Entity" ,true, (ret) => 
        //{ 
        //    obj = ret;
        //    isLoading = true;
        //});
        //await UniTask.WaitUntil(() => isLoading == true);

        //// Ǯ ������Ʈ �ε� _ Projectile
        //isLoading = false;
        //ResourceManager.GetInstance().UTaskGetResource(ResourceType.Projectile, $"Projectile", true, (ret) =>
        //{
        //    obj = ret;
        //    isLoading = true;
        //});
        //await UniTask.WaitUntil(() => isLoading == true);

        //// Ǯ ������Ʈ �ε� _ Effect
        //isLoading = false;
        //ResourceManager.GetInstance().UTaskGetResource(ResourceType.Effect,$"Effect", true, (ret) =>
        //{
        //    obj = ret;
        //    isLoading = true;
        //});
        //await UniTask.WaitUntil(() => isLoading == true);
    }
}
