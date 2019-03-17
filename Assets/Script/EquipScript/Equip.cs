using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    none,
    Weapon,
    Helm,
    ChestArmor,
    LegArmor,
    Boots,
    Glass,
    MouthEquip
}

public class Equip : MonoBehaviour {
    
    public string Name;
    public EquipType type;
    public List<PlayerStateAttribute> EquipAttributesList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
