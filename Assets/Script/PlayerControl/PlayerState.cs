using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxMana { get; set; }
    public int CurrentMana { get; set; }
    public int MaxWealth { get; set; }
    public int CurrentWealth { get; set; }

    
    private int CurrentAttack { get; set; }
    private int CurrentDefense { get; set; }
    private int CurrentSpeed { get; set; }
    //命中率
    //回避率

    

 
    // Use this for initialization
    void Start () {
		

    }

    public void Equip(Equip equip,bool PutOn)
    {
        if (equip == null)
            return;
        int i = PutOn ? 1 : -1;
        foreach(EquipAttribute e in equip.AttributesList)
        {
            switch (e.type)
            {
                case EquipAttributeType.Attack:
                    CurrentAttack += e.value * i;
                    break;
                case EquipAttributeType.Defense:
                    CurrentDefense += e.value * i;
                    break;
                case EquipAttributeType.Speed:
                    CurrentSpeed += e.value * i;
                    break;
                default:
                    break;
            }
        }
    }

    
	



  


   



}
