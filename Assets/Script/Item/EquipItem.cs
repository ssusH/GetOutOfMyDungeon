using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : Item {

    public  GameObject ItemInstancePrefab;
    public EquipType type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerEquip>().PutOnEquit(ItemInstancePrefab,type);
        Destroy(gameObject);
    }
}
