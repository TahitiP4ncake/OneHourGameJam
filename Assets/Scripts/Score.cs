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
    private static Score singleton;
    void Awake () {
        //scoreManager = GetComponent<scoreManager>();
       // creator = GetComponent<PlayerCreator>();
        text = GetComponent<Text>();
        score1 = 0;
        score2 = 0;
        score3 = 0;
        score4 = 0;

        if (singleton != null && singleton != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Create singleton instance
            singleton = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }
    public static Score Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("no score manager display");
                return null;
            }

            return singleton;
        }
    }
    void Update () {
        if(creator.numberOfPlayer==0)
        {
            text.text = "appuyez sur A";
        }
        if(creator.numberOfPlayer==1)
        {
           
            text.text = "joueur 1 : " + score1;
        }
        if (creator.numberOfPlayer == 2)
        {
            
            text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2;
        }
        if (creator.numberOfPlayer == 3)
        {
            
            text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3;
        }
        if (creator.numberOfPlayer ==4)
        {
            
            text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3 + " joueur 4 : " + score4;
        }


        //text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3 + " joueur 4 : " + score4;
        
	}
    
}
