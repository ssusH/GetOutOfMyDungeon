using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour {

    public GameObject ItemPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PickUp()
    {
        if (BackpackPanel.instance.AddItem(ItemPrefab))
            Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
            PickUp();
    }
}
