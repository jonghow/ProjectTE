using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface AbnormalSustainable
{
    public abstract void OnUpdateAbnormal(float _smoothDeltaTime);
}

public class AbnormalBase : AbnormalSustainable, IDisposable
{
    public AbnormalType _abnormalType;
    public float _duration;
    public float _values1; 
    public float _values2;

    public virtual void Dispose()
    {
        _abnormalType = AbnormalType.None;
        _duration = 0f;
        _values1 = 0f;
        _values2 = 0f;
    }

    public virtual void OnUpdateAbnormal(float _smoothDeltaTime)
    {
        _duration -= _smoothDeltaTime;
    }
    public bool isTimeOut() => _duration <= 0 ? true : false;
}
