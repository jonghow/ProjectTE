using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GlobalTypeJob
{
    Fighter,         // 전사
    Shielder,       // 방패병
    Archer,          // 궁사
    Mage,            // 마법사
    
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