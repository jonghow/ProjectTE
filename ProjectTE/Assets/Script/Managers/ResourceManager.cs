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

        // 없다면,
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

        // 없다면,
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

        // 캐시된 AssetBundle이 있는지 확인하고, 없으면 비동기 로드
        if (!_dic_AssetBundle.TryGetValue(_bundleType, out _bundle))
        {
            // AssetBundle 비동기 로드 작업 시작
            var _myLoadedAssetBundle = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, "testassetbundle"));

            // 로드가 완료될 때까지 기다림
            await _myLoadedAssetBundle;

            _bundle = _myLoadedAssetBundle.assetBundle;

            // AssetBundle이 null이면 로드 실패 처리
            if (_bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                return null;
            }

            // 로드된 에셋 번들을 캐시에 추가
            _dic_AssetBundle.Add(_bundleType, _bundle);
        }

        // 특정 자산 비동기 로드
        var _targetAsset = _bundle.LoadAssetAsync<UnityEngine.Object>("SampleMonster");

        // 자산 로드가 완료될 때까지 대기
        await _targetAsset;

        var _asset = _targetAsset.asset;

        // 콜백 실행 (콜백이 null이 아닐 경우)
        _callback?.Invoke(_asset);

        // 로드된 자산 반환
        return _asset;
    }
}