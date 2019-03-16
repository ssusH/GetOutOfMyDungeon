using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[RequireComponent(typeof(TipPanel))]
public class PrepareRoom : MonoBehaviour {
     
    public GameObject BeginButton;

    private GameObject ChooseCharacter { set; get; }

    private TipPanel tipPanel;

    public int currentPrepareSum { get;  set; }
    public int maxRoomSize { get;  set; }

    [SerializeField]
    private List<GameObject> CharacterList;
    private bool isReady = false;

    public GameObject CharaterBar;
    public GameObject PrepareSumBar;

    public PlayerSetup localPlayer { get; set; }
    
    public PrepareRoom()
    {
        currentPrepareSum = 0;
        maxRoomSize = 0;
    }

    private void Awake()
    {
        
        //GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
    }
    // Use this for initialization
    void Start () {

        tipPanel = GetComponent<TipPanel>();
        
    }


    public void SetChooseCharacter(GameObject obj)
    {
        if (isReady)
            return;
        if(ChooseCharacter!=null)
        {
            ChooseCharacter.GetComponent<Image>().color = Color.white;
        }
        ChooseCharacter = obj;
        ChooseCharacter.GetComponent<Image>().color = Color.red;
    }

    public void ReadyBegin()
    {
        if (ChooseCharacter == null)
        {
            tipPanel.CreatTipsPanel("请选择你的角色...",3f);
            return;
        }
        localPlayer.ReadyGame();
    }



    public void setCurrentPrepareSumText(int sum)
    {
        PrepareSumBar.transform.Find("CurrentPrepareSum").GetComponent<Text>().text = sum.ToString();
    }

    public void setMaxPrepareSumText(int sum)
    {
        PrepareSumBar.transform.Find("MaxRoomSize").GetComponent<Text>().text = "/ " + sum.ToString();
    }

    public void setBeginButtonText(string str)
    {
        BeginButton.GetComponentInChildren<Text>().text = str;
    }

    public void setCharacterMask(bool _isReady)
    {
        isReady = _isReady;
        for (int i = 0; i < CharacterList.Count; i++)
        {
            if (CharacterList[i].name == ChooseCharacter.name)
                continue;
            CharacterList[i].transform.Find("Panel").gameObject.SetActive(isReady);

        }
    }

  
}

