using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GlobalTypeJob
{
    Fighter,
    Archer,
    Mage
}

public enum AbnormalType
{
    None,

    // Mez
    Stun,
    Confused,

    // Buff
    BuffAttackUp,

    // Debuff
    DebuffAttackDown,

    End
}