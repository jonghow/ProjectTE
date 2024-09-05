using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager
{
    public static PathManager Instance;

    public static PathManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new PathManager();
        }

        return Instance;
    }

    public string assetPath_Prefab = $"../Object/";
}
