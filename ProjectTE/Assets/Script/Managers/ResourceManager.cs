using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public enum ResourceType
{
    Entity,
    Projectile,
    Effect
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
    private Dictionary<AssetBundleType, AssetBundle> _dic_AssetBundle = new Dictionary<AssetBundleType, AssetBundle>();

    Coroutine _routines;
    CancellationTokenSource _cancellation;

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

    // Unitask
    public async void UTaskGetResource(AssetBundleType _bundleType, ResourceType _resourceType,string _fileName, bool _isCache, Action<UnityEngine.Object> _callback)
    {
        UnityEngine.Object _ret = null;

        if (_dic_Objects.TryGetValue(_resourceType, out _ret))
        {
            _callback.Invoke(_ret);
            return;
        }

        _cancellation?.Cancel();
        UnityEngine.Object _loadingObject = await UTGetResourceA(_bundleType, _resourceType, _fileName, _isCache, _callback);
    }

    // Coroutine
    public IEnumerator RoutineGetResource(ResourceType _resourceType, bool _isCache, Action<UnityEngine.Object> _callback)
    {
        UnityEngine.Object _ret = null;

        // ���ٸ�,
        //string path = Application.dataPath + $"/ResourceData/00.Entity/Entity";
        string path =  $"Entity";
        var resourceRequest = Resources.LoadAsync<UnityEngine.Object>(path);

        yield return new WaitUntil(() => !resourceRequest.isDone);

        _ret = resourceRequest.asset as UnityEngine.Object;

        if (_dic_Objects.ContainsKey(_resourceType) == false)
            _dic_Objects.Add(_resourceType, _ret);

        _callback?.Invoke(_ret);
    }

    private async UniTask<UnityEngine.Object> UTGetResource(ResourceType _resourceType,string _fileName, bool _isCache, Action<UnityEngine.Object> _callback)
    {
        UnityEngine.Object _ret = null;

        // ���ٸ�,
        //string path = Application.dataPath + $"/ResourceData/00.Entity/Entity";
        string path = $"Entity";
        var resourceRequest = Resources.LoadAsync<UnityEngine.Object>(path);

        await UniTask.WaitUntil(() => resourceRequest.isDone == true);

        _ret = resourceRequest.asset as UnityEngine.Object;

        if(_isCache == true)
        {
            if (_dic_Objects.ContainsKey(_resourceType) == false)
                _dic_Objects.Add(_resourceType, _ret);
        }

        _callback?.Invoke(_ret);
        return _ret;
    }

    private async UniTask<UnityEngine.Object> UTGetResourceA(AssetBundleType _bundleType, ResourceType _resourceType, string _fileName, bool _isCache, Action<UnityEngine.Object> _callback)
    {
        AssetBundle _bundle = null;

        // ĳ�õ� AssetBundle�� �ִ��� Ȯ���ϰ�, ������ �񵿱� �ε�
        if (!_dic_AssetBundle.TryGetValue(_bundleType, out _bundle))
        {
            // AssetBundle �񵿱� �ε� �۾� ����
            var _myLoadedAssetBundle = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, "testassetbundle"));

            // �ε尡 �Ϸ�� ������ ��ٸ�
            await _myLoadedAssetBundle;

            _bundle = _myLoadedAssetBundle.assetBundle;

            // AssetBundle�� null�̸� �ε� ���� ó��
            if (_bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                return null;
            }

            // �ε�� ���� ������ ĳ�ÿ� �߰�
            _dic_AssetBundle.Add(_bundleType, _bundle);
        }

        // Ư�� �ڻ� �񵿱� �ε�
        var _targetAsset = _bundle.LoadAssetAsync<UnityEngine.Object>("SampleMonster");

        // �ڻ� �ε尡 �Ϸ�� ������ ���
        await _targetAsset;

        var _asset = _targetAsset.asset;

        // �ݹ� ���� (�ݹ��� null�� �ƴ� ���)
        _callback?.Invoke(_asset);

        // �ε�� �ڻ� ��ȯ
        return _asset;
    }
}