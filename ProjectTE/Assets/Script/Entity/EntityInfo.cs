using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInfo 
{
    public EntityInfo()
    {
        _hp = 100;
        _maxhp = _hp;

        _skillEnerge = 100;
        _maxSkillEnerge = _skillEnerge ;

        _isDead = false;

        _status = new EntityStatus();
    }


    private int _hp;
    private int _maxhp;

    private int _skillEnerge;
    private int _maxSkillEnerge;

    private bool _isDead;

    private EntityStatus _status;
}
