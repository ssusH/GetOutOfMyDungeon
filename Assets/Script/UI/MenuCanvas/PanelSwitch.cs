using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitch : MonoBehaviour {

    [SerializeField]
    public MenuState[] PanelList;
    
    [SerializeField]
    private List<MenuState> HotkeyPanelList = new List<MenuState>();

    [SerializeField]
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


    public void SwitchTo(MenuState panel, MenuAnimationType type)
    {
        switch (type)
        {
            case MenuAnimationType.NONE:
                if (nowPanel != null)
                {
                    ClosePanel(nowPanel);
                }
                nowPanel = panel;
                panel.gameObject.SetActive(true);
                nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 1;
                nowPanel.isOpen = true;
                break;
            case MenuAnimationType.UPHD:
                if (nowPanel != null)
                {
                    ClosePanel(nowPanel);
                }
                nowPanel = panel;
                nowPanel.menuObj.GetComponent<Animator>().Play("switchPanel");
                nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 1;
                nowPanel.isOpen = true;
                break;
            default:
                break;

        }

        

    }

    public void ClosePanel(MenuState panel)
    {
        switch (panel.animationType)
        {
            case MenuAnimationType.NONE:
                panel.gameObject.SetActive(false);
                nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 0;
                nowPanel.isOpen = false;
                break;
            case MenuAnimationType.UPHD:
                nowPanel.menuObj.GetComponent<Animator>().Play("backPanel");
                nowPanel.menuObj.GetComponent<Canvas>().sortingOrder = 0;
                nowPanel.isOpen = false;
                break;
            default:
                break;


        }
        nowPanel = null;
        
    }

    private void HotKeyPanel()
    {
        if (HotkeyPanelList.Count != 0)
        {
            for (int i = 0; i < HotkeyPanelList.Count; i++)
            {
                if(Input.GetKeyDown(HotkeyPanelList[i].HotKey))
                {
                    GameManager.instance.PlayerActStop(!HotkeyPanelList[i].isOpen);
                    if (!HotkeyPanelList[i].isOpen)
                    {
                        SwitchTo(HotkeyPanelList[i], HotkeyPanelList[i].animationType);
                        
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
