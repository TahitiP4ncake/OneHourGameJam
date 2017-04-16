using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public x360_Gamepad gamepad;
    GamepadManager manager;

    public int score1;
    public int score2;
    public int score3;
    public int score4;

    private Text text;
    public scoreManager scoreManager;
    public PlayerCreator creator;
	void Awake () {
        //scoreManager = GetComponent<scoreManager>();
       // creator = GetComponent<PlayerCreator>();
        text = GetComponent<Text>();
        score1 = 0;
        score2 = 0;
        score3 = 0;
        score4 = 0;

    }
	
	void Update () {
        if(creator.numberOfPlayer==0)
        {
            text.text = "appuyez sur A";
        }
        if(creator.numberOfPlayer==1)
        {
            score1 = scoreManager.score1;
            text.text = "joueur 1 : " + score1;
        }
        if (creator.numberOfPlayer == 2)
        {
            score2 = scoreManager.score2;
            text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2;
        }
        if (creator.numberOfPlayer == 3)
        {
            score3 = scoreManager.score3;
            text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3;
        }
        if (creator.numberOfPlayer ==4)
        {
            score4 = scoreManager.score4;
            text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3 + " joueur 4 : " + score4;
        }


        //text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3 + " joueur 4 : " + score4;
        
	}
    
}
