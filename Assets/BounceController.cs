using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BounceController : MonoBehaviour {
    //gamepad
    public x360_Gamepad gamepad;
    GamepadManager manager;
    
    [Header("parametres vitesse")]
    //control values
    public float speed;
    public float maxSpeed;
    public float downSpeed;
    public bool onTheWall;
    private bool checkSide;
    [Space]
    [Header("parametres dash")]
    //dash values 
    public float dashSpeed;
    public float dashDuration;
    public float dashCooldown;
    private bool dashOn;
    [Space]
    [Header("parametres dash")]
    //bounce properties
    private float relativeSpeed;
    public float detectionRange;
    private bool checkCollision;
    private Vector3 bounceDirection;
    public float bounceIntensity;
    public float gravityForce;
    public float gravityTimer;
    private bool falling;
    [Space]
    [Header("parametres fight")]
    public float bouncePlayerForce;
    private bool isAttacking;

    //gameObjects
    [Space]
    [Header("parametres Player")]
    private Rigidbody rb;
    public int papa;
    public GameObject colorChanger;
    public int score1;
    public int score2;
    public int score3;
    public int score4;
    public Score scoreManager;
    void Start () {
        manager = GamepadManager.Instance;
        gamepad = manager.GetGamepad(papa);
        rb = GetComponent<Rigidbody>();
        scoreManager = Score.Instance;
       
        //GetComponentInChildren<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //renderer.material.SetColor("_ToonShade",myColor);
        colorChanger.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        if (papa == 1)
        {
            scoreManager.score1 = 0;
        }
        if (papa == 2)
        {
            scoreManager.score2 =0;
        }
        if (papa == 3)
        {
            scoreManager.score3 =0;
        }
        if (papa == 4)
        {
            scoreManager.score4 =0;
        }
    }


    void Update () {
        
        //Debug.Log(gamepad.GetStick_L().Y);
		if(((gamepad.GetStick_L().X)>0.2f || (gamepad.GetStick_L().X) <-0.2f))
        {
            
            //&& rb.velocity.x<maxSpeed
            Move();
        }
        
        
        if(gamepad.GetButtonDown("A") && !dashOn)
        {
            dashOn = true;
            StartCoroutine(DashTimer());
        }
        if(gamepad.GetStick_L().Y!=0 && onTheWall)
        {
            moveDown();
        }
        if(gamepad.GetButton("X"))
        {
            Stop();
        }
        if(gamepad.GetButton("Start"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if(gamepad.GetButtonDown("Y"))
        {
            colorChanger.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        }
        
	}

    void FixedUpdate()
    {
        if (gamepad.GetStick_L().Y == 0 && onTheWall)
        {
            rb.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration);
            rb.velocity = rb.velocity / 2;
        }
        /*
        if (onTheWall)
        {
            rb.AddForce(Vector3.down*gravityForce, ForceMode.Acceleration);
        }
        */
        //rb.AddForce(Vector3.down * gravityForce, ForceMode.Force);
        //detection des bords
        //il y a surement un moyen plus propre mais bon, on verra bien
        if (checkCollision)
        {
            checkCollision = false;
            //checkCollision = false;
            if (Physics.Raycast(transform.position, Vector3.down, detectionRange))
            {
                Bounce(Vector3.up);
                //Debug.Log("en bas");
            }

            if (Physics.Raycast(transform.position, Vector3.up, detectionRange))
            {
                Bounce(Vector3.down);
                //Debug.Log("en haut");
            }
        }
        if(checkSide)
        {
            checkSide = false;
        if (Physics.Raycast(transform.position, Vector3.right, detectionRange))
        {
            onTheWall = true;

            // Bounce(Vector3.left);
            //Debug.Log("a droite");
        }

        if (Physics.Raycast(transform.position, Vector3.left, detectionRange))
        {
            onTheWall = true;

            //Bounce(Vector3.right);
            //Debug.Log("a gauche");
        }

    }
        if(onTheWall)
        {
            rb.useGravity = false;
        }
        
    }

    void Move()
    {
        rb.AddForce(Vector3.right * speed * gamepad.GetStick_L().X, ForceMode.Acceleration);
    }
    
    void Stop()
    {
        rb.velocity = rb.velocity / 10;
    }
    void moveDown()
    {
        rb.AddForce(Vector3.up * gamepad.GetStick_L().Y * downSpeed , ForceMode.Acceleration);
    }

    void Bounce(Vector3 direction)
    {
        StopCoroutine(DashTimer());
        dashOn = false;
        //direction.y = direction.y + relativeSpeed;
        rb.AddForce(direction*bounceIntensity, ForceMode.VelocityChange);       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player" && !isAttacking)
        {
            
            Bounce(((transform.position - other.transform.position)/bouncePlayerForce));
            //Debug.Log("touché");
        }
        if (other.collider.tag == "Player" && isAttacking)
        {

            // Destroy(other.gameObject);
            other.gameObject.tag = "Respawn";
            AddPoint();
           
            //other.gameObject.SetActive(false);

            //Debug.Log("touché");
        }
        {
            checkCollision = true;
            relativeSpeed = other.relativeVelocity.y/10;
        }
        
    }

    void OnCollisionStay(Collision other)
    {
        
        
        if(other.collider.tag !="Player")
        {
            checkSide = true;
        }
        
    }

    void OnCollisionExit(Collision other)
    {
        if(onTheWall)
        {
            onTheWall = false;
            rb.useGravity = true;
        }
    }

    void Dash()
    {
        
        rb.AddForce(new Vector3(gamepad.GetStick_L().X, gamepad.GetStick_L().Y, 0) * dashSpeed, ForceMode.VelocityChange);
        
    }

    void AddPoint()
    {
        if (papa == 1)
        {
            scoreManager.score1 += 1;
        }
        if (papa == 2)
        {
            scoreManager.score2 += 1;
        }
        if (papa == 3)
        {
            scoreManager.score3 += 1;
        }
        if (papa == 4)
        {
            scoreManager.score4 += 1;
        }
    }

    IEnumerator DashTimer()
    {
        Vector3 _velocity = Vector3.zero;
        Dash();
       
        isAttacking = true;
        yield return new WaitForSecondsRealtime(dashDuration);
        isAttacking = false;
        rb.velocity = rb.velocity / 4;
        yield return new WaitForSecondsRealtime(dashCooldown);
        dashOn = false;
    }

    IEnumerator getDown()
    {
        yield return new WaitForSecondsRealtime(gravityTimer);
         rb.AddForce(Vector3.down * gravityForce, ForceMode.VelocityChange);
    }
}
