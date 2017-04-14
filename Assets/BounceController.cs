using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float detectionRange;
    private bool checkCollision;
    private Vector3 bounceDirection;
    public float bounceIntensity;
    public float gravityForce;
    public float gravityTimer;
    private bool falling;
    [Space]
    //gameObjects
    private Rigidbody rb;

    void Start () {
        manager = GamepadManager.Instance;
        gamepad = manager.GetGamepad(1);
        rb = GetComponent<Rigidbody>();    
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
    
    void moveDown()
    {
        rb.AddForce(Vector3.up * gamepad.GetStick_L().Y * downSpeed , ForceMode.Acceleration);
    }

    void Bounce(Vector3 direction)
    {
        StopCoroutine(DashTimer());
        dashOn = false;
        rb.AddForce(direction*bounceIntensity, ForceMode.VelocityChange);       
    }

    void OnCollisionEnter(Collision other)
    {
        checkCollision = true;
    }

    void OnCollisionStay(Collision other)
    {
        checkSide = true;
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

    IEnumerator DashTimer()
    {
        Vector3 _velocity = Vector3.zero;
        //float velocityScale = 1;
        Dash();
        yield return new WaitForSecondsRealtime(dashDuration);
        //rb.velocity = rb.velocity / 4;
        //_velocity = rb.velocity;
        rb.velocity = rb.velocity / 4;


        //yield return new WaitForSecondsRealtime(dashDuration);
        //rb.velocity = _velocity/4;
        yield return new WaitForSecondsRealtime(dashCooldown);
        dashOn = false;
    }

    IEnumerator getDown()
    {
        yield return new WaitForSecondsRealtime(gravityTimer);
         rb.AddForce(Vector3.down * gravityForce, ForceMode.VelocityChange);
        
    }
}
