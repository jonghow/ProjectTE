using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PoolingManager
{
    public static PoolingManager Instance;

    public static PoolingManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new PoolingManager();
        }

        return Instance;
    }

    private Dictionary<PooledObject, Dictionary<PooledObject, GameObject>> _dicPoolObject = new Dictionary<PooledObject, Dictionary<PooledObject, GameObject>>();

    public void Init()
    {
        _dicPoolObject.Clear();

        InitCreatePoolObject();
    }

    private void InitCreatePoolObject()
    {





    }
}
