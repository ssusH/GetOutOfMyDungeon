using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : Item {

    public  GameObject ItemInstancePrefab;
    public EquipType type;
    public bool isEquiped = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public override void  UseItem(GameObject gameObject)
    {
        if (!isEquiped)
        {
            gameObject.GetComponent<PlayerEquip>().PutOffEquit(type);
            gameObject.GetComponent<PlayerEquip>().PutOnEquit(ItemInstancePrefab, type);
        }
        else
        {
            gameObject.GetComponent<PlayerEquip>().PutOffEquit(type);
        }

        isEquiped = !isEquiped;
       
    }

    public override void RemoveItem()
    {
        if(isEquiped)
        {
            gameObject.GetComponent<PlayerEquip>().PutOffEquit(type);
        }
        BackpackPanel.instance.RemoveItem(this);
    }
}
