using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatus
{

    public EntityStatus()
    {
        _strength = 10;
        _dexterity = 10;
        _wisdom = 10;
        _guts = 10;
        _mental = 10;
        
        // 2�� ����
        _physicalAtk = 10f;
        _magicalAtk = 10f;

        _hitRate = 10f;
        _evasionRate = 10f;

        _physicalCriticalAtkRate = 10f;
        _magicalCriticalAtkRate = 10f;

        _physicalCriticalAtkDamageInc = 10f;
        _magicalCriticalAtkDamageInc = 10f;

        _buffEfficiency = 10f;

        _physicalDef = 10f;
        _magicalDef = 10f;

        _physicalCriticalAtkBlockRate = 10f;
        _magicalCriticalAtkBlockRate = 10f;

        _physicalCriticalAtkDamageDec = 10f;
        _magicalCriticalAtkDamageDec = 10f;
    }

    /*
     * 1�� ����
     * ��
     * ��ø
     * ����
     * �ټ�
     * ����
     */

    private int _strength;
    private int _dexterity;
    private int _wisdom;
    private int _guts;
    private int _mental;

    /* 
     * 2�� ���� 
     * ���� ����
     * ���� ����
     * ���߷�
     * ȸ����
     * ���� ġ��Ÿ
     * ���� ġ��Ÿ
     * ���� ġ��Ÿ ����
     * ���� ġ��Ÿ ���� 
     * ���� ȿ�� ( �������� ���� ȿ���� �ø��ų�, ���� �ð� ���� �ø� �� �ֵ��� �Ѵ�.)
     * ���� ����
     * ���� ����
     * ���� ġ��Ÿ �����
     * ���� ġ��Ÿ �����
     * ���� ġ��Ÿ ������
     * ���� ġ��Ÿ ������
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
