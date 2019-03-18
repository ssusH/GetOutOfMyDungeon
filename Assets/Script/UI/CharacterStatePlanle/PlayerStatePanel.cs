using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatePanel : MonoBehaviour {


    public static PlayerStatePanel instance;

    [Header("角色属性栏")]
    public Transform PlayerAttackAttributeSolt;
    public Transform PlayerDefenseAttributeSolt;
    public Transform PlayerSpeedAttributeSolt;
    public Transform PlayerMaxHealthAttributeSolt;
    public Transform PlayerMaxManaAttributeSolt;
    public Transform PlayerMaxWealthAttributeSolt;
    [Header("角色装备栏")]
    public Transform PlayerWeaponSolt;
    public Transform PlayerHelmSolt;
    public Transform PlayerChestArmorSolt;
    public Transform PlayerLegArmorSolt;
    public Transform PlayerMiscellaneous_1_Solt;
    public Transform PlayerMiscellaneous_2_Solt;




    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("has only one gamemanager");
        }
        instance = this;
    }

    public void UpdatePlayerStatePanel(List<PlayerStateAttribute> state)
    {
        foreach(PlayerStateAttribute att in state)
        {
            switch (att.type)
            {
                case PlayerStateAttributeType.Attack:
                    SetPlayerStatePanel(PlayerAttackAttributeSolt, att);
                    break;
                case PlayerStateAttributeType.Defense:
                    SetPlayerStatePanel(PlayerDefenseAttributeSolt, att);
                    break;                  
                case PlayerStateAttributeType.Speed:
                    SetPlayerStatePanel(PlayerSpeedAttributeSolt, att);
                    break;                    
                case PlayerStateAttributeType.MaxHealth:
                    SetPlayerStatePanel(PlayerMaxHealthAttributeSolt, att);
                    break;
                case PlayerStateAttributeType.MaxMana:
                    SetPlayerStatePanel(PlayerMaxManaAttributeSolt, att);
                    break;
                case PlayerStateAttributeType.MaxWealth:
                    SetPlayerStatePanel(PlayerMaxWealthAttributeSolt, att);
                    break;
                default:
                    break;
            }
        }
    }

    private void SetPlayerStatePanel(Transform solt,PlayerStateAttribute att)
    {
        solt.Find("a_value").GetComponent<Text>().text = att.value.ToString();
    }

    public void UpdateEquipSolt(Equip equip,bool PutOn)
    {
        switch (equip.type)
        {
            case EquipType.Weapon:
                SetEquipSolt(PlayerWeaponSolt, equip, PutOn);
                break;
            case EquipType.Helm:
                SetEquipSolt(PlayerHelmSolt, equip, PutOn);
                break;
            case EquipType.ChestArmor:
                SetEquipSolt(PlayerChestArmorSolt, equip, PutOn);
                break;
            case EquipType.LegArmor:
                SetEquipSolt(PlayerLegArmorSolt, equip, PutOn);
                break;
            case EquipType.Boots:
                break;
            case EquipType.Glass:
                SetEquipSolt(PlayerMiscellaneous_1_Solt, equip, PutOn);
                break;
            default:
                break;

        }
    }

    private void SetEquipSolt(Transform solt, Equip equip, bool PutOn)
    {
        if(PutOn)
        {
            solt.transform.Find("Text").gameObject.SetActive(false);
            solt.transform.Find("Image").GetComponent<Image>().sprite = equip.gameObject.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            solt.transform.Find("Image").GetComponent<Image>().sprite = null;
            solt.transform.Find("Text").gameObject.SetActive(true);
            
        }
    }


}
