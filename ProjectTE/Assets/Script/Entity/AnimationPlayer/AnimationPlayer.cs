using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer 
{
    [SerializeField] Animator _animator;

    public void PlayAnimation(string _clipName)
    {
        if (_animator == null) return;

        _animator.Play($"{_clipName}");
    }
}
