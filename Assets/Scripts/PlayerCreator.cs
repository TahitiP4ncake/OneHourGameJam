using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour {
    public x360_Gamepad gamepad1;
    public x360_Gamepad gamepad2;
    public x360_Gamepad gamepad3;
    public x360_Gamepad gamepad4;


    public bool player1;
    public bool player2;
    private bool player3;
    private bool player4;

    private int nombreDeGamepad;
    public int numberOfPlayer;
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
        //Debug.Log(numberOfPlayer);
        nombreDeGamepad = manager.ConnectedTotal();


        
            if (gamepad1.GetButtonDown("A") && player1
                == false)
            {
                player1 = true;
                numberOfPlayer += 1;
                CreatePlayer(1, playerObject);
                //numberOfPlayer = 1;
            }
            
                if (gamepad2.GetButtonDown("A") && player2 == false)
                {
                    player2 = true;
                    numberOfPlayer += 1;
                    CreatePlayer(2, playerObject);
                    
                }
            
            /*
                if (gamepad3.GetButtonDown("A") && player3 == false)
                {
                    player3 = true;
                    numberOfPlayer += 1;
                    CreatePlayer(3, playerObject);
                }
            
            
                if (gamepad4.GetButtonDown("A") && player4 == false)
                {
                    player4 = true;
                    numberOfPlayer += 1;
                    CreatePlayer(4, playerObject);
                }
            */
        

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
        if(createur==1)
        {
            _Player = Instantiate(modele, new Vector3(-7.6f,0,0), transform.rotation) as GameObject;
        }
        else
        {
            _Player = Instantiate(modele, new Vector3(7.6f, 0, 0), transform.rotation) as GameObject;
        }
       
        //numberOfPlayer += 1;
        _Player.GetComponent<BounceController>().papa = createur;
       

        //_Player.GetComponentInChildren<Renderer>().material.color =  Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //_Player.tag = "Player";
        //_controller = manager.GetGamepad(nombreDeVoiture);
        //Voitures.Add(_voiture);
        return _Player;
    }
}
