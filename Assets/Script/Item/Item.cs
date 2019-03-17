using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    none,
    Equip,
    Consumables,//消耗品
}

//道具品质
//public class ItemQuality
//{
 
//}

public class Item : MonoBehaviour {

    public string Name { get; set; }
    protected int MaxSize = 1;
    protected int CurrentSum = 1;
    protected ItemType ItemType;
    

    // Use this for initialization
    void Start () {
        UpdateItemState();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UseItem(GameObject tagert)
    {

    }

    public bool EqualsItemName(Item item)
    {
        return (Name == item.Name);
    }

    public void AddCurrentSum(ref Item item)
    {
        //补充物品，如果物品不同直接返回，如果相同则尽量补满。然后更新
        if (!EqualsItemName(item))
        {
            return;
        }
        if(CurrentSum+item.CurrentSum>MaxSize)
        {
            CurrentSum = MaxSize;
            item.CurrentSum -= (MaxSize - CurrentSum);

        }
        else
        {
            CurrentSum += item.CurrentSum;
            item.CurrentSum = 0;
            
        }
        UpdateItemState();
    }
    public int GetCurrentSum()
    {
        return CurrentSum;
    }

    public void UpdateItemState()
    {
        transform.Find("ItemCount").GetComponent<Text>().text = CurrentSum <= 1 ? "":CurrentSum.ToString();
    }
}
