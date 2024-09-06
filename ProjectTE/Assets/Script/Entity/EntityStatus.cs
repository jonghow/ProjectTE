using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatus 
{
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
