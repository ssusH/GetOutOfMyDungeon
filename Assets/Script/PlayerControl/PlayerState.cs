using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(PlayerMovement))]
public class PlayerState : MonoBehaviour {

    private int MaxHealth { get; set; }
    private int CurrentHealth { get; set; }
    private int MaxMana { get; set; }
    private int CurrentMana { get; set; }
    private int MaxWealth { get; set; }
    private int CurrentWealth { get; set; }
    
    
    private int CurrentAttack { get; set; }
    private int CurrentDefense { get; set; }
    private int CurrentSpeed { get; set; }
    //命中率
    //回避率

    private PlayerMovement playerMovement;
    public CharacterDesign CharacterBaseData;


    // Use this for initialization
    void Start () {
        
        playerMovement = GetComponent<PlayerMovement>();

        PlayerInitialized(CharacterBaseData);
    }

    public void Equip(Equip equip,bool PutOn)
    {
        if (equip == null)
            return;
        int i = PutOn ? 1 : -1;
        foreach(PlayerStateAttribute e in equip.EquipAttributesList)
        {
            switch (e.type)
            {
                case PlayerStateAttributeType.Attack:
                    CurrentAttack += e.value * i;
                    break;
                case PlayerStateAttributeType.Defense:
                    CurrentDefense += e.value * i;
                    break;
                case PlayerStateAttributeType.Speed:
                    CurrentSpeed += e.value * i;
                    break;
                case PlayerStateAttributeType.MaxHealth:
                    MaxHealth += e.value * i;
                    break;
                case PlayerStateAttributeType.MaxMana:
                    MaxMana += e.value * i;
                    break;
                case PlayerStateAttributeType.MaxWealth:
                    MaxWealth += e.value * i;
                    break;

                default:
                    break;
            }
        }
        PlayerStatePanel.instance.UpdateEquipSolt(equip,PutOn);
        PlayerStatePanel.instance.UpdatePlayerStatePanel(GetCurrentStateValue());

    }

    //返回一个PlayerStateAttribute列表形式的角色属性列表
    private List<PlayerStateAttribute> GetCurrentStateValue()
    {
        List<PlayerStateAttribute> AttList = new List<PlayerStateAttribute>();
        PlayerStateAttribute att = new PlayerStateAttribute(PlayerStateAttributeType.Attack, CurrentAttack);
        AttList.Add(att);
        att = new PlayerStateAttribute(PlayerStateAttributeType.Defense, CurrentDefense);
        AttList.Add(att);
        att = new PlayerStateAttribute(PlayerStateAttributeType.Speed, CurrentSpeed);
        AttList.Add(att);
        att = new PlayerStateAttribute(PlayerStateAttributeType.MaxHealth, MaxHealth);
        AttList.Add(att);
        att = new PlayerStateAttribute(PlayerStateAttributeType.MaxMana, MaxMana);
        AttList.Add(att);
        att = new PlayerStateAttribute(PlayerStateAttributeType.MaxWealth, MaxWealth);
        AttList.Add(att);
        
        return AttList;
    }

    //设置PlayerStateAttribute列表为角色当前属性
    private void SetCurrentStateValue(List<PlayerStateAttribute> attList)
    {
        foreach (PlayerStateAttribute att in attList)
        {
            switch (att.type)
            {
                case PlayerStateAttributeType.Attack:
                    CurrentAttack = att.value;
                    break;
                case PlayerStateAttributeType.Defense:
                    CurrentDefense = att.value;
                    break;
                case PlayerStateAttributeType.Speed:
                    CurrentSpeed = att.value;
                    break;
                case PlayerStateAttributeType.MaxHealth:
                    MaxHealth = att.value;
                    break;
                case PlayerStateAttributeType.MaxMana:
                    MaxMana = att.value;
                    break;
                case PlayerStateAttributeType.MaxWealth:
                    MaxWealth = att.value;
                    break;
                default:
                    break;
            }
        }
    }



    //设置角色移动状态，用于暂停角色操作
    public void SetPlayerMoveState(bool stop)
    {
        playerMovement.stop = stop;
        playerMovement.setMoveVectors(Vector2.zero);
        GetComponent<Animator>().SetFloat("speed", 0.5f);
    }

    private void PlayerInitialized(CharacterDesign baseData )
    {
        if(baseData == null)
        {
            baseData = new CharacterDesign();
        }
        MaxHealth = baseData.BaseHealth;
        MaxMana = baseData.BaseMana;
        MaxWealth = baseData.BaseWealth;
        CurrentAttack = baseData.BaseAttack;
        CurrentDefense = baseData.BaseDefense;
        CurrentSpeed = baseData.BaseSpeed;

        PlayerStatePanel.instance.UpdatePlayerStatePanel(GetCurrentStateValue());

    }













}
