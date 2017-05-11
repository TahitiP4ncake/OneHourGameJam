using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
    public x360_Gamepad gamepad;
    GamepadManager manager;

    public int score1;
    public int score2;
    public int score3;
    public int score4;

    public int death;

    public int lose;

    public bool player1;
    public bool player2;

    private Text text;

    public Text WIN;
    public Text Restart;
    public Text Tuto;
    public scoreManager scoreManager;
    public PlayerCreator creator;
    private static Score singleton;

    public GameObject playerCreator;

    public x360_Gamepad gamepad1;
    public x360_Gamepad gamepad2;
    public x360_Gamepad gamepad3;
    public x360_Gamepad gamepad4;

    public GameObject ground;
    public GameObject LD;

    public bool winner;

    // tuto
    private bool X1;
    private bool X2;
    private bool A1;
    private bool A2;

    private int tutoState;

    void Awake () {
       
        manager = GamepadManager.Instance;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        Tuto.text = "Press A to start                     (Back to skip the tutorial)";
        gamepad1 = manager.GetGamepad(1);
        gamepad2 = manager.GetGamepad(2);
        
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

        if (gamepad1.GetButton("Start"))
        {

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            tutoState = 4;
            StartCoroutine(LaunchGame());
        }
        if (gamepad2.GetButton("Start"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            tutoState = 4;
            StartCoroutine(LaunchGame());
        }
        if (gamepad1.GetButton("Back"))
        {
            StopAllCoroutines();
            player1 = false;
            player2 = false;
            winner = false;
            WIN.text = "";
            Restart.text = "";
            death = 0;
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            GameObject[] _player = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in _player)
            {
                Destroy(player);
            }
                StartCoroutine(LaunchGame());
            creator.numberOfPlayer = 0;
            creator.player1 = false;
            creator.player2 = false;
        }
        if (gamepad2.GetButton("Back"))
        {
            StopAllCoroutines();
            player1 = false;
            player2 = false;
            winner = false;
            WIN.text = "";
            Restart.text = "";
            death = 0;
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            GameObject[] _player = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in _player)
            {
                Destroy(player);
            }
            StartCoroutine(LaunchGame());
            creator.numberOfPlayer = 0;
            creator.player1 = false;
            creator.player2 = false;
        }
        if (gamepad1.GetButtonDown("X"))
        {
            X1 = true;
        }
        if (gamepad2.GetButtonDown("X"))
        {
            X2 = true;
        }
        if (gamepad1.GetButtonDown("A"))
        {
            A1 = true;
        }
        if (gamepad2.GetButtonDown("A"))
        {
            A2= true;
        }

        if((tutoState==1 )&& X1 && X2)
        {
            A1 = false;
            A2 = false;
            Tuto.text = "Use A and the left joystick to dash";
            tutoState = 2;
        }
        
        if (tutoState == 2 && A1 == true && A2==true)
        {
            Tuto.text = "Maybe the world is too small for both of you... ";
            //Debug.Log("tuto3");
            tutoState = 3;
        }
        
        if(score1 +score2>0 && tutoState==3)
        {
            tutoState = 4;
            Tuto.text = "Don't touch those walls, it will kill you ...";
        }

        if(tutoState==4)
        {
            tutoState = 5;
            
            StartCoroutine(LaunchGame());
        }
        /*
        if (gamepad3.GetButton("Start"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (gamepad4.GetButton("Start"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        */
        if(tutoState==5)
        {
            text.text = "Player 1 : " + score1 + "                  Player 2 : " + score2;
        }
        
        if (creator.numberOfPlayer==0)
        {
            //text.text = "Score";
        }
        if(creator.numberOfPlayer==1)
        {
           
            //text.text = "joueur 1 : " + score1;
        }
        if (creator.numberOfPlayer == 2)
        {
            
            
            
            if (tutoState == 0)
            {
                Tuto.text = "Use X to stop";
                tutoState = 1;
            }
        }
        if (creator.numberOfPlayer == 3)
        {
            
            //text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3;
        }
        if (creator.numberOfPlayer ==4)
        {
            
           // text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3 + " joueur 4 : " + score4;
        }

        if(winner)
        {
            if (score1 > score2)
            {
                WIN.text = "PLAYER 1 WINS";
                StartCoroutine(Slow());
            }
            // Restart.text = "Press start to restart ";
            if (score2>score1)
            {
                WIN.text = "PLAYER 2 WINS";
                StartCoroutine(Slow());

            }
        }
       
        //text.text = "joueur 1 : " + score1 + " joueur 2 : " + score2 + " joueur 3 : " + score3 + " joueur 4 : " + score4;

    }
    IEnumerator Slow()
    {
        StartCoroutine(Camera.main.GetComponent<cameraEffect>().Shake());
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 0.01f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        yield return new WaitForSecondsRealtime(0.8f);
        Restart.text = "Press Back to restart ";


        /*
         Time.timeScale = 1;
         Time.fixedDeltaTime = 0.02f;
         */
    }
    IEnumerator LaunchGame()
    {
        tutoState = 5;
        score1 = 0;
        score2 = 0;
        yield return new WaitForSecondsRealtime(.5f);
        
        Tuto.text = "";
        LD.SetActive(true);
        ground.SetActive(false);
    }
}
