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
                    UpdateStateValueSolt(PlayerAttackAttributeSolt, att);
                    break;
                case PlayerStateAttributeType.Defense:
                    UpdateStateValueSolt(PlayerDefenseAttributeSolt, att);
                    break;                  
                case PlayerStateAttributeType.Speed:
                    UpdateStateValueSolt(PlayerSpeedAttributeSolt, att);
                    break;                    
                case PlayerStateAttributeType.MaxHealth:
                    UpdateStateValueSolt(PlayerMaxHealthAttributeSolt, att);
                    break;
                case PlayerStateAttributeType.MaxMana:
                    UpdateStateValueSolt(PlayerMaxManaAttributeSolt, att);
                    break;
                case PlayerStateAttributeType.MaxWealth:
                    UpdateStateValueSolt(PlayerMaxWealthAttributeSolt, att);
                    break;
                default:
                    break;
            }
        }
    }

    private void UpdateStateValueSolt(Transform solt,PlayerStateAttribute att)
    {
        solt.Find("a_value").GetComponent<Text>().text = att.value.ToString();
    }
}
