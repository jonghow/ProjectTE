using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityCategory
{
    PlayerTeam,
    EnemyTeam1,
    EnemyTeam2,
    Obstacle,
    Projectile,
    Max
}

public class EntityManager
{
    public static EntityManager Instance;

    public static EntityManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new EntityManager();
        }

        return Instance;
    }

    public Dictionary<EntityCategory, Dictionary<long, Entity>> DicEntities = new Dictionary<EntityCategory, Dictionary<long, Entity>>();
    public void AddObject(EntityCategory _category, long _uid, Entity _entity)
    {
        if (DicEntities.ContainsKey(_category) == false)
            DicEntities.Add(_category, new Dictionary<long, Entity>());

        DicEntities[_category].Add(_uid, _entity);
    }

    public void GetObject(EntityCategory _category, long _uid, out Entity _entity)
    {
        Dictionary<long, Entity> _uidPair = null;
        _entity = null;

        if (DicEntities.TryGetValue(_category, out _uidPair))
        {
            if (_uidPair.TryGetValue(_uid, out _entity))
            {
            }
        }
    }

    public void GetEntityList(EntityCategory _category, out List<Tuple<long, Entity>> _listEntities)
    {
        if (DicEntities.ContainsKey(_category) == false)
            DicEntities.Add(_category, new Dictionary<long, Entity>());

        _listEntities = new List<Tuple<long, Entity>>();

        foreach (var pair in DicEntities[_category])
        {
            _listEntities.Add(new Tuple<long, Entity>(pair.Key, pair.Value));
        }
    }
}