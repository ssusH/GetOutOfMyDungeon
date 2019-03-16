using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : MonoBehaviour {

    public GameObject TipPanelPrefab;

    private GameObject TipsPanel;


  
    public void CreatTipsPanel(string str, float time)
    {
        if (TipsPanel == null)
            TipsPanel = Instantiate(TipPanelPrefab, transform);
        TipsPanel.transform.Find("Text").GetComponent<Text>().text = str;
        Invoke("CloseTipsPanel", time);
    }

    public void CreatTipsPanel(string str)
    {
        if(TipsPanel == null)
            TipsPanel = Instantiate(TipPanelPrefab, transform);
        TipsPanel.transform.Find("Text").GetComponent<Text>().text = str;
    }

    public void CloseTipsPanel()
    {
        if (TipsPanel != null)
            Destroy(TipsPanel);
        TipsPanel = null;
    }
}
