using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIType
{
    Transition,
    TouchBlock,
    Max
}

public class UIManager
{
    public static UIManager Instance;

    public static UIManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new UIManager();
        }

        return Instance;
    }

    private Dictionary<UIType, List<GameObject>> dicUIObject = new Dictionary<UIType, List<GameObject>>();
    public void OpenUI(UIType type, GameObject obj)
    {
        if(dicUIObject.ContainsKey(type))
        {

        }
    }
}