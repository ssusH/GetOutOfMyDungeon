using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EquipAttributeType
{
    none,
    Attack,
    Defense,
    Speed,
}

[System.Serializable]
public class EquipAttribute {

    public EquipAttributeType type;
    public int value;

    public EquipAttribute()
    {
        type = EquipAttributeType.none;
        value = 0;
    }

}
