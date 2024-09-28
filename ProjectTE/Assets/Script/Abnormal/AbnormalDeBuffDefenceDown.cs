using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbnormalDeBuffDefenceDown : AbnormalBase
{
    public override void OnUpdateAbnormal(float _smoothDeltaTime)
    {
        _duration -= _smoothDeltaTime;
    }
}
