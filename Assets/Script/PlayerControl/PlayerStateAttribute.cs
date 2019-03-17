using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerStateAttributeType
{
    none,
    Attack,
    Defense,
    Speed,
    MaxHealth,
    MaxMana,
    MaxWealth,

}

[System.Serializable]
public class PlayerStateAttribute {

    public PlayerStateAttributeType type;
    public int value;

    private PlayerStateAttribute()
    {
        type = PlayerStateAttributeType.none;
        value = 0;
    }

    public PlayerStateAttribute(PlayerStateAttributeType type,int value)
    {
        this.type = type;
        this.value = value;
    }

}
