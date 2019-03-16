using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LANGameMatch : MonoBehaviour {

    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();

        }
    }

    public void LANHost()
    {
        networkManager.StartHost();
    }

    public void LANClient()
    {
        networkManager.StartClient();
    }
}
