using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitch : MonoBehaviour {

    [SerializeField]
    public MenuState[] PanelList;
    
    [SerializeField]
    private List<MenuState> HotkeyPanelList = new List<MenuState>();

    private MenuState nowPanel;
    public MenuState MainPanel;
	// Use this for initializatio


	void Start () {
        nowPanel = MainPanel;
        for(int i = 0;i<PanelList.Length;i++)
        {
            if(PanelList[i].HotKey!=KeyCode.None)
            {
                HotkeyPanelList.Add(PanelList[i]);
            }
        }
	}

     void Update()
    {
        HotKeyPanel();
    }


    public void SwitchTo(MenuState panel)
    {
        if (nowPanel != null)
        {
            nowPanel.menuObj.GetComponent<Animator>().Play("backPanel");
            nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 0;
            nowPanel.isOpen = false;
        }
        nowPanel = panel;
        nowPanel.menuObj.GetComponent<Animator>().Play("switchPanel");
        nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 1;
        nowPanel.isOpen = true;

    }

    public void ClosePanel(MenuState panel)
    {
        if (nowPanel != null)
        {
            nowPanel.menuObj.GetComponent<Animator>().Play("backPanel");
            nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 0;
            nowPanel.isOpen = false;
        }
    }

    private void HotKeyPanel()
    {
        if (HotkeyPanelList.Count != 0)
        {
            for (int i = 0; i < HotkeyPanelList.Count; i++)
            {
                if(Input.GetKeyDown(HotkeyPanelList[i].HotKey))
                {
                    if(!HotkeyPanelList[i].isOpen)
                    {
                        SwitchTo(HotkeyPanelList[i]);
                    }
                    else
                    {
                        ClosePanel(HotkeyPanelList[i]);
                    }
                }
            }
        }
    }


    
}
