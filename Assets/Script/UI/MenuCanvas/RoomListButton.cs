
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class RoomListButton : MonoBehaviour {


    public Text RoomName;
    public Text RoomSize;

    public delegate void JoinRoomDelegate(MatchInfoSnapshot _match);
    public JoinRoomDelegate joinRoomDelegate;
    private MatchInfoSnapshot match;

    public void SetRoomButton(MatchInfoSnapshot _match, JoinRoomDelegate joinFunction)
    {
        match = _match;
        joinRoomDelegate = joinFunction;
        SetRoomInfo(match.name, match.currentSize + "/" + match.maxSize);
    }

    public void JoinGame()
    {
        joinRoomDelegate.Invoke(match);
    }

    private void SetRoomInfo(string roomName , string roomSize)
    {
        RoomName.text = roomName;
        RoomSize.text = roomSize;
    }

}
