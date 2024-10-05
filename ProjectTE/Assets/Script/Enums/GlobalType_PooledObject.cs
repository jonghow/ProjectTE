using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PooledObject
{
    /*
     * ī�װ� ���� ������.
     * Object
     * 
     * UI
     * 
     * Effect
     * 
     * 
     * 
     */
    Object,
    UI,
    Effect,
}

public enum PooledObjectInner
{
    /*
     * Object Type Inner : ���� ī�װ��� �ǹ��Ѵ�. 
     */

    Object_Projectile,
    // TODO : �߻�ü�� ���� 2D Sprite�� ���Ƴ����ٵ�, �̰Ŵ� ���θ���°� ������ ���Ƴ���°� ������ üũ�غ����Ѵ�.

    UI_NameTag,
    UI_DamageText,

    Effect_FootStep,
    Effect_SkillFx,
    Effect_SkillParticle
}