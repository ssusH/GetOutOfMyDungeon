using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {



    private static Dictionary<string, PlayerState> PlayerList = new Dictionary<string, PlayerState>();

    public static GameManager instance;

    private const string PLAYER_ID_PREFIX = "Player";

    private PlayerState nowPlayer;

    public GameObject prepareRoomPrefab;
    private GameObject prepareRoom;

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

    public void SetNowPlayer(PlayerState player)
    {
        nowPlayer = player;
    }

    public void PlayerActStop(bool stop)
    {
        nowPlayer.SetPlayerMoveState(stop);
    }

    //public static void RegisterPlayer(string _netID, PlayerState _player)
    //{
    //    string _playerID = PLAYER_ID_PREFIX + _netID;
    //    PlayerList.Add(_playerID, _player);
    //    _player.transform.name = _playerID;
    //}

    //public void RemovePlayer(string name)
    //{
    //    PlayerList.Remove(name);
    //}

    //public PrepareRoom GetPrepareRoom()
    //{
    //    if(prepareRoom == null)
    //        prepareRoom = Instantiate(prepareRoomPrefab);

    //    return prepareRoom.GetComponent<PrepareRoom>();
    //}


}
