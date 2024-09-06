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
        Debug.Log($"[UserEntityFactory] CreateEntity()");
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