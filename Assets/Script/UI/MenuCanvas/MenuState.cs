using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
public class MenuState : MonoBehaviour {


    public enum MenuType
    {
        CAX, //常按形
        QHX, //切换形
    }

    public string menuName;
    public bool isOpen = false;
    public MenuType menuType;
    public KeyCode HotKey;
    public GameObject menuObj;


        // Use this for initialization
    void Start () {
        menuName = transform.name;
        menuObj = transform.gameObject;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
