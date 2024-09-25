using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AbnormalSystem : IDisposable
{
    private Dictionary<AbnormalType, Queue<AbnormalBase>> _dic_Abnormal = new Dictionary<AbnormalType, Queue<AbnormalBase>>();

    public void Dispose()
    {
        foreach (var pairAbnormal in _dic_Abnormal)
        {
            var q = pairAbnormal.Value;

            foreach (var abnormalBase in q)
            {
                abnormalBase.Dispose();
            }

            q.Clear();
        }

        _dic_Abnormal.Clear();
    }

    public void OnUpdateAbnormals(float smoothDeltaTime)
    {
        foreach(var pairAbnormal in _dic_Abnormal)
        {
            var q = pairAbnormal.Value;

            foreach(var abnormalBase in q)
            {
                abnormalBase.OnUpdateAbnormal(smoothDeltaTime);
            }
        }
    }
}
