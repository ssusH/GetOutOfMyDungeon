using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerEquip))]
public class PlayerSetup_Local : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.SetNowPlayer(this.GetComponent<PlayerState>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
