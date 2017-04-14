using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {
    public x360_Gamepad gamepad;
    GamepadManager manager;
	// Use this for initialization
	void Start () {
        manager = GamepadManager.Instance;
        gamepad = manager.GetGamepad(1);
	}
	
	// Update is called once per frame
	void Update () {
		if(gamepad.GetButton("A"))
        {
            Debug.Log("oui");
        }
	}
}
