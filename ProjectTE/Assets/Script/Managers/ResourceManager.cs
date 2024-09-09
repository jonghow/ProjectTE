using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Entity
}

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public static ResourceManager GetInstance()
    {
        if (Instance == null)
        {
            GameObject obj = new GameObject("ResourceManager");
            Instance = obj.AddComponent<ResourceManager>();
        }

        return Instance;
    }

    private Dictionary<ResourceType, UnityEngine.Object> _dic_Objects = new Dictionary<ResourceType, UnityEngine.Object>();

    Coroutine _routines;

    public void GetResource(ResourceType _resourceType, bool _isCache, Action<UnityEngine.Object> _callback)
    {
        UnityEngine.Object _ret = null;

        if (_dic_Objects.TryGetValue(_resourceType, out _ret))
        {
            _callback.Invoke(_ret);
            return;
        }

        if(_routines != null)
        {
            StopCoroutine(_routines);
            _routines = null;
        }

        _routines = StartCoroutine(RoutineGetResource(_resourceType, _isCache, _callback));
    }

    public IEnumerator RoutineGetResource(ResourceType _resourceType, bool _isCache, Action<UnityEngine.Object> _callback)
    {
        UnityEngine.Object _ret = null;

        // ¾ø´Ù¸é,
        //string path = Application.dataPath + $"/ResourceData/00.Entity/Entity";
        string path =  $"Entity";
        var resourceRequest = Resources.LoadAsync<UnityEngine.Object>(path);

        yield return new WaitUntil(() => !resourceRequest.isDone);

        _ret = resourceRequest.asset as UnityEngine.Object;

        if (_dic_Objects.ContainsKey(_resourceType) == false)
            _dic_Objects.Add(_resourceType, _ret);

        _callback.Invoke(_ret);
    }
}