using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerState))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private bool isReady = false; //准备就绪
    [SerializeField]
    private bool onGame = false;  //游戏中

    public PrepareRoom prepareRoom;
    


    // Use this for initialization
    void Start () {

        PrepareRoom();
        //gameObject.name = "LocalPlayer";
        //gameObject.name = "RemotePlayer";
        //不至于让其他玩家报错


    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public override void OnStartClient()
    {
        base.OnStartClient();
        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        GameManager.RegisterPlayer(_netID, GetComponent<PlayerState>());
    }
    

  
    private void OnDisable()
    {
        if (isLocalPlayer)
        {
            //GameManager.instance.ChangeMainCameraStatu(true);
            //Destroy(BattleUi);
        }
        if(isReady)
        {
            CmdGetCurrentParpentSum(-1);
        }
        CmdGetMaxParpentSum(-1);
        GameManager.instance.RemovePlayer("Player"+ GetComponent<NetworkIdentity>().netId.ToString());


    }


 

    #region 准备大厅


    public void PrepareRoom()
    {
        prepareRoom = GameObject.Find("GameManager").GetComponent<GameManager>().GetPrepareRoom();
        if (isLocalPlayer)
        {
            prepareRoom.localPlayer = this;
            CmdGetCurrentParpentSum(0);
            CmdGetMaxParpentSum(1);
            if (isServer)
            {
                prepareRoom.setBeginButtonText("开始");

            }
            else if (isClient)
            {
                prepareRoom.setBeginButtonText("准备");
            }
        }
    }


    [Command]
    public void CmdGetCurrentParpentSum(int add)
    {
        prepareRoom.currentPrepareSum += add;
        RpcGetCurrentParpentSum(prepareRoom.currentPrepareSum);
    }

    [ClientRpc]
    void RpcGetCurrentParpentSum(int _currentPrepareSum)
    {
        prepareRoom.setCurrentPrepareSumText(_currentPrepareSum);
    }

    [Command]
    public void CmdGetMaxParpentSum(int add)
    {
        prepareRoom.maxRoomSize += add;
        RpcGetMaxParpentSum(prepareRoom.maxRoomSize);
    }

    [ClientRpc]
    void RpcGetMaxParpentSum(int _MaxPrepareSum)
    {
        prepareRoom.setMaxPrepareSumText(_MaxPrepareSum);
    }

    public void ReadyGame()
    {

        if (isServer)
        {
            Debug.Log("开始比赛");
            isReady = !isReady;
            int sum = -1;
            if (isReady)
            {
                sum = 1;
            }
            CmdGetCurrentParpentSum(sum);
            prepareRoom.setCharacterMask(isReady);

        }
        else if (isClient)
        {
            isReady = !isReady;
            string ready = "";
            int sum = -1;
            if (isReady)
            {
                ready = "取消";
                sum = 1;
            }
            CmdGetCurrentParpentSum(sum);
            prepareRoom.setCharacterMask(isReady);
            prepareRoom.setBeginButtonText( ready + "准备");
        }
        
    }
    #endregion
}
