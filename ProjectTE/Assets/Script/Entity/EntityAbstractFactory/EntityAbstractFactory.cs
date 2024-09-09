using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityAbsFactoryBase
{
    public Entity CreateEntity();
}

public abstract class EntityFactoryBase : IEntityAbsFactoryBase
{
    public abstract Entity CreateEntity();
}

public class UserEntityFactory : EntityFactoryBase
{
    public override Entity CreateEntity()
    {
        ResourceManager.GetInstance().GetResource(ResourceType.Entity, true, (obj) => {

            var gObj = GameObject.Instantiate(obj) as GameObject;
            var entity = gObj.GetComponent<Entity>();

            UUIDGenerator<long> uUIDGenerator = UUIDGenerator<long>.GetInstance();
            var uUID = uUIDGenerator.Generate();

            EntityManager.GetInstance().AddObject(EntityCategory.PlayerTeam, uUID, entity);

            Debug.Log($"[UserEntityFactory] CreateEntity() Success");
        } );

        return null;
    }
}

public class RivalEntityFactory : EntityFactoryBase
{
    public override Entity CreateEntity()
    {
        Debug.Log($"[RivalEntityFactory] CreateEntity()");
        return null;
    }
}