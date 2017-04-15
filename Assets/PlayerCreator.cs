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
    private bool player3;
    private bool player4;

    private int nombreDeGamepad;
    private int numberOfPlayer;
    public GameObject playerObject;
    private GamepadManager manager;
    

    void Start()
    {
        manager = GamepadManager.Instance;
        gamepad1 = manager.GetGamepad(1);
        gamepad2 = manager.GetGamepad(2);
        gamepad3 = manager.GetGamepad(3);
        gamepad4 = manager.GetGamepad(4);

    }

        // Update is called once per frame
        void Update () {
        
        nombreDeGamepad = manager.ConnectedTotal();


        if (nombreDeGamepad >= 1)
        {
            if (gamepad1.GetButtonDown("A") && player1
                == false)
            {
                player1 = true;
                CreatePlayer(1, playerObject);
            }
            if (nombreDeGamepad >= 2)
            {
                if (gamepad2.GetButtonDown("A") && player2 == false)
                {
                    player2 = true;
                    CreatePlayer(2, playerObject);
                }
            }
            if (nombreDeGamepad >= 3)
            {
                if (gamepad3.GetButtonDown("A") && player3 == false)
                {
                    player3 = true;
                    CreatePlayer(3, playerObject);
                }
            }
            if (nombreDeGamepad >= 4)
            {
                if (gamepad4.GetButtonDown("A") && player4 == false)
                {
                    player4 = true;
                    CreatePlayer(4, playerObject);
                }
            }
        }

        /*
		if(gamepad1.GetButtonDown("A")&& !player1)
        {
            //Debug.Log("1");
            player1 = true;
            CreatePlayer(1,playerObject);
        }

        if (gamepad2.GetButtonDown("A") && !player2)
        {
            //Debug.Log("2");
            player2 = true;
            CreatePlayer(2,playerObject);
        }
        */
    }
    GameObject CreatePlayer(int createur, GameObject modele)
    {
        GameObject _Player;
        _Player = Instantiate(modele, transform.position, transform.rotation) as GameObject;
        numberOfPlayer += 1;
        _Player.GetComponent<BounceController>().papa = createur;
       

        //_Player.GetComponentInChildren<Renderer>().material.color =  Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //_Player.tag = "Player";
        //_controller = manager.GetGamepad(nombreDeVoiture);
        //Voitures.Add(_voiture);
        return _Player;
    }
}
