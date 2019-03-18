using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackPanel : MonoBehaviour {

    public static BackpackPanel instance;

    private const int BackpackSize = 12;

    [SerializeField]
    private Item[] ItemList = new Item[BackpackSize] ;
    [SerializeField]
    private Transform[] ItemSolt =  new Transform[BackpackSize];

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("has only one gamemanager");
        }
        instance = this;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AddItem(GameObject item)
    {
        //把没放满的道具先放满
        for(int i = 0;i<ItemList.Length;i++)
        {
            if (ItemList[i] == null)
            {//放到空位上
                 
                ItemList[i] = Instantiate(item, ItemSolt[i]).GetComponent<Item>();
                return true;
            }
        }
        return false;
    }
    public void RemoveItem(Item item)
    {
        Destroy(item.gameObject);
    }


 
}
