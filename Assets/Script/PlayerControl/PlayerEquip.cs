using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerState))]
public class PlayerEquip : MonoBehaviour {

    public Equip Weapon { get; private set ; } //武器
    public Equip Helm { get; private set; } //头盔
    public Equip ChestArmor { get; private set; } //胸甲
    public Equip LegArmor { get; private set; } //腿甲
    public Equip Boots { get; private set; } //鞋子
    public Equip Miscellaneous_1 { get; private set; } //杂项1
    public Equip Miscellaneous_2 { get; private set; } //杂项2

    public Transform WeaponSolt;
    public Transform HelmSolt;
    public Transform ChestArmorSolt;
    public Transform LegArmorSolt;
    public Transform BootsSolt;
    public Transform EysSolt;
    public Transform MouthSolt;

    private PlayerState PlayerState;
    // Use this for initialization  
    void Start () {
        PlayerState = GetComponent<PlayerState>();
	}

    

    public void PutOnEquit(GameObject EquipPrefab, EquipType type)
    {
        Equip equip = null;

        //穿之前，先脱去身上同类型装备
        PutOffEquit(type);

        //按照类别将装备装到指定槽位置
        switch (type)
        {
            case EquipType.Weapon:
                equip = Instantiate(EquipPrefab,WeaponSolt).GetComponent<Equip>();
                Weapon = equip;
                //Equip(equip, WeaponSolt);
                break;
            case EquipType.Helm:
                equip = Instantiate(EquipPrefab, HelmSolt).GetComponent<Equip>();
                Helm = equip;
                break;
            case EquipType.ChestArmor:
                equip = Instantiate(EquipPrefab, ChestArmorSolt).GetComponent<Equip>();
                ChestArmor = equip;
                break;
            case EquipType.LegArmor:
                equip = Instantiate(EquipPrefab, LegArmorSolt).GetComponent<Equip>();
                LegArmor = equip;
                break;
            case EquipType.Boots:
                equip = Instantiate(EquipPrefab, BootsSolt).GetComponent<Equip>();
                Boots = equip;
                break;
            case EquipType.Glass:
                equip = Instantiate(EquipPrefab, EysSolt).GetComponent<Equip>();
                break;
            //case EquipType.MouthEquip:
            //    Equip(equip, MouthSolt);
            //    break;
            default:
                break;

        }
        //更新角色属性值
        PlayerState.Equip(equip, true);

    }

    public void PutOffEquit(EquipType equip)
    {
        switch (equip)
        {
            case EquipType.Weapon:
                PlayerState.Equip(Weapon, false);
                UnEquip( WeaponSolt);
                break;
            case EquipType.Helm:
                PlayerState.Equip(Helm, false);
                UnEquip( HelmSolt);
                break;
            case EquipType.ChestArmor:
                PlayerState.Equip(ChestArmor, false);
                UnEquip( ChestArmorSolt);
                break;
            case EquipType.LegArmor:
                PlayerState.Equip(LegArmor, false);
                UnEquip( LegArmorSolt);
                break;
            case EquipType.Boots:
                PlayerState.Equip(Boots, false);
                UnEquip( BootsSolt);
                break;
            case EquipType.Glass:
                UnEquip(EysSolt);
                break;
            //case EquipType.MouthEquip:
            //    UnEquip( MouthSolt);
            //    break;
            default:
                break;
        }
        
    }

    
    public void Equip(Equip equip,Transform solt)
    {
      
 
    }
    
    public void UnEquip(Transform solt)
    {
        //销毁装备到玩家形象
        for(int i = 0;i<solt.childCount;i++)
        {
            Destroy(solt.GetChild(i).gameObject);
        }
    }

}
