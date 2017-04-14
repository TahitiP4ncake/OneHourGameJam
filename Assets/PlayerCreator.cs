using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour {
    public x360_Gamepad gamepad1;
    public x360_Gamepad gamepad2;
    public x360_Gamepad gamepad3;
    public x360_Gamepad gamepad4;

    private bool player1;
    private bool player2;
   

    private int numberOfPlayer;
    public GameObject playerObject;
    private GamepadManager manager;
    // Use this for initialization

    void Start()
    {
        manager = GamepadManager.Instance;
        gamepad1 = manager.GetGamepad(1);
        gamepad2 = manager.GetGamepad(2);
      
        
    }

        // Update is called once per frame
        void Update () {
		if(gamepad1.GetButton("A")&& !player1)
        {
            player1 = true;
            CreatePlayer(1);
        }
        
        if (gamepad2.GetButton("A") && !player2)
        {
            player2 = true;
            CreatePlayer(2);
        }
        
    }
    GameObject CreatePlayer(int createur)
    {
        GameObject _Player;
        _Player = Instantiate(playerObject, transform.position, transform.rotation) as GameObject;
        numberOfPlayer += 1;
        _Player.GetComponent<BounceController>().papa = createur;


        _Player.tag = "Player";
        //_controller = manager.GetGamepad(nombreDeVoiture);
        //Voitures.Add(_voiture);
        return _Player;
    }
}
