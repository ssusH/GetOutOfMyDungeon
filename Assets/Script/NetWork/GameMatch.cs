using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class GameMatch : MonoBehaviour {

    private NetworkManager networkManager;

    public List<GameObject> roomList = new List<GameObject>();

    [SerializeField]
    private Transform RoomListPlane;
    [SerializeField]
    private GameObject RoomListButtonPrefab;


    private TipPanel MainMenuTip;
    private string RoomName = "";
    private uint RoomSize = 2;
    private string PassWord = "";

   



    public void SetRoomName(string roomName)
    {

        RoomName = roomName;
    }
    public void SetRoomSize(string roomSize)
    {

        RoomSize = uint.Parse(roomSize);
    }
    public void SetPassWord(string passWord)
    {

        PassWord = passWord;
    }

     void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
        MainMenuTip = GameObject.Find("MainMenu").GetComponent<TipPanel>();

     


    }

   

    public void CreatHost()
    {
        if (RoomName == "")
        {
            MainMenuTip.CreatTipsPanel("房间名不能为空！",3f);
            return;
        }
        if ( RoomSize < 2 || RoomSize > 6 )
        {
            MainMenuTip.CreatTipsPanel("房间尺寸限于2至6人！",3f);
            return;
        }
        MainMenuTip.CreatTipsPanel("创建房间中...");

        NetworkMatch.DataResponseDelegate<MatchInfo> CreatRoomCallback = new NetworkMatch.DataResponseDelegate<MatchInfo>(networkManager.OnMatchCreate);
        CreatRoomCallback += MatchCreate;
        networkManager.matchMaker.CreateMatch(RoomName, 4, true, PassWord, "", "", 0, 0, CreatRoomCallback);
    }



    public void MatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Creat Success:"+RoomName+"/"+RoomSize+"/"+PassWord);
        }
        else
        {
            MainMenuTip.CreatTipsPanel("房间创建失败！", 3f);
        }
    }

    public void RefreshRoomList()
    {
        MainMenuTip.CreatTipsPanel("刷新房间列表！");

        networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
    }

    private void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
    {
        ClearRoomList();
        if (!success)
        {
            MainMenuTip.CreatTipsPanel("房间信息获取出错！\nExtendedInfo:" + extendedInfo, 2f); 
            return;
        }
        if (responseData == null || responseData.Count == 0)
        {
            MainMenuTip.CreatTipsPanel("没有获取到房间信息！", 2f);
            
            return;
        }
        foreach (MatchInfoSnapshot match in responseData)
        {

            GameObject _room = (GameObject)Instantiate(RoomListButtonPrefab, RoomListPlane);
            _room.GetComponent<RoomListButton>().SetRoomButton(match, joinMatch);
            roomList.Add(_room);
        }
        MainMenuTip.CreatTipsPanel("刷新成功！", 2f);

    }
    public void joinMatch(MatchInfoSnapshot match)
    {
        MainMenuTip.CreatTipsPanel("进入房间中...");
        NetworkMatch.DataResponseDelegate<MatchInfo> JoinRoomCallback = new NetworkMatch.DataResponseDelegate<MatchInfo>(networkManager.OnMatchJoined);
        JoinRoomCallback += MatchJoined;
        networkManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, JoinRoomCallback);
    }

    public void MatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        if (success)
        {
            Debug.Log("Join Success:");
        }
        else
        {
            MainMenuTip.CreatTipsPanel("房间加入失败！", 3f);
        }
    }

 

    private void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }
        roomList.Clear();
    }


}
