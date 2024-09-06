using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatus 
{
    /*
     * 1차 스탯
     * 힘
     * 민첩
     * 지능
     * 근성
     * 정신
     */

    private int _strength;
    private int _dexterity;
    private int _wisdom;
    private int _guts;
    private int _mental;

    /* 
     * 2차 스탯 
     * 물리 공격
     * 마법 공격
     * 적중률
     * 회피율
     * 물리 치명타
     * 마법 치명타
     * 물리 치명타 증가
     * 마법 치명타 증가 
     * 버프 효율 ( 버프량에 대한 효율을 올리거나, 지속 시간 등을 올릴 수 있도록 한다.)
     * 물리 방어력
     * 마법 방어력
     * 물리 치명타 방어율
     * 마법 치명타 방어율
     * 물리 치명타 감소율
     * 마법 치명타 감소율
     */
    private double _physicalAtk;    
    private double _magicalAtk;

    private double _hitRate;
    private double _evasionRate;

    private double _physicalCriticalAtkRate;
    private double _magicalCriticalAtkRate;

    private double _physicalCriticalAtkDamageInc;
    private double _magicalCriticalAtkDamageInc;

    private double _buffEfficiency;

    private double _physicalDef;
    private double _magicalDef;

    private double _physicalCriticalAtkBlockRate;
    private double _magicalCriticalAtkBlockRate;

    private double _physicalCriticalAtkDamageDec;
    private double _magicalCriticalAtkDamageDec;
}
