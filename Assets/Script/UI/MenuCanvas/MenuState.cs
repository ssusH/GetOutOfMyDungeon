using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuType
{
    CAX, //常按形
    QHX, //切换形
}
public enum MenuAnimationType
{
    NONE,//无动画，直接出现
    UPHD,//上滑动
}

[RequireComponent(typeof(Canvas))]
[RequireComponent(typeof(GraphicRaycaster))]
public class MenuState : MonoBehaviour {


   


    public string menuName;
    public bool isOpen = false;
    public MenuType menuType;
    public MenuAnimationType animationType;
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
