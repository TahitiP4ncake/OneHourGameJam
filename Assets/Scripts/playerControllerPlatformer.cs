using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerPlatformer : MonoBehaviour {
    //gamepad
    public x360_Gamepad gamepad;
    GamepadManager manager;

    //player bool
    private bool jump;
    private bool grounded;
    private bool walled;

    //parametre controller
    public GameObject Aspirateur;
    private Rigidbody rb;

    public float bulletSpeed;
    public int munition;
    public float Speed;
    public float maxSpeed;
    public float jumpForce;
    public float suckForce;
    public GameObject bullet;
    public Transform gun;
    public float bigBalle;
    public float recul;

    private int size;
    private float wallDirection;
    private RaycastHit hit;
    private bool Control;
    private float x;
    private float Rx;
    private float y;
    private Vector3 Direction;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.1f;
    private GameObject _balle;
    private cameraEffect shaker;

    public float vitesse;

    void Start () {
        manager = GamepadManager.Instance;
        gamepad = manager.GetGamepad(1);
        rb = GetComponent<Rigidbody>();
        Control = true;
        shaker = Camera.main.GetComponent<cameraEffect>();
    }
	
	// Update is called once per frame
	void Update () {
        x = gamepad.GetStick_L().X;
        y = gamepad.GetStick_L().Y;
        Direction  = new Vector3(0,0, (Mathf.Atan2(y, x) * 180 / Mathf.PI)+90);
        CheckInput();
        Rx = gamepad.GetStick_R().X;
        vitesse = rb.velocity.x;
        //Debug.Log(Physics.Raycast(transform.position, Vector3.down, .5f));
       // Debug.Log((Mathf.Atan2(gamepad.GetStick_R().Y, gamepad.GetStick_R().X) * 180 / Mathf.PI) + 90);
	}

    void CheckInput()
    {
        Ground();

       
        if(WallCheck()&& !grounded)
        {
            WallJump();
        }
        else
        {
            if (rb.useGravity == false)
            {
                rb.useGravity = true;
            }
            if ( walled)
            {
                walled = false;
            }
            Move();
            
        }
        Jump();
       
        Aim();

        Suck();
    }

    void Ground()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, .5f);
    }

    bool WallCheck()
    {
        if ((Physics.Raycast(transform.position, Vector3.right, .3f)))
        {
            wallDirection = -1;
            return true;
        }
        else if (Physics.Raycast(transform.position, Vector3.left, .3f))
        {
            wallDirection = 1;
            return true;
        }
        else
        {
            
            return false;
        }
       
    }

    void WallJump()
    {
        rb.useGravity = false;

        if (!jump)
        {
            rb.velocity = Vector3.zero;
        }
        /*
        if(gamepad.GetButtonDown("A"))
        {
            StartCoroutine(controlBack());
            rb.AddForce(rb.velocity = (new Vector3(-wallDirection*Speed, jumpForce)));
        }
*/

    }

    void Move()
    {

        if(Mathf.Abs(x)>.3f)
        {
            rb.velocity=(new Vector3(x * Speed, rb.velocity.y, 0));
           // rb.AddForce(new Vector3(), ForceMode.Force);
        }
        if(Mathf.Abs(rb.velocity.x)>maxSpeed)
        {
            //rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if(gamepad.GetButtonDown("A")&& !jump)
        {
            jump = true;
            Control = false;
            StartCoroutine(controlBack());
            /*
            if (Physics.Raycast(transform.position, Vector3.right, .26f))
            {
                rb.AddForce  (new Vector3(-3, jumpForce),ForceMode.VelocityChange);
            }
            else if (Physics.Raycast(transform.position, Vector3.left, .26f))
            {
                rb.AddForce  (new Vector3(3, jumpForce),ForceMode.VelocityChange);
            }
            */
            if (WallCheck())
            {
                rb.velocity = (new Vector3(wallDirection * Speed, jumpForce));
            }
            else
            {
                rb.velocity = (new Vector3(rb.velocity.x, jumpForce));
            }
            

        }

    }

    void Suck()
    {
        if(gamepad.GetButtonDown("X") && munition>0)
        {
            munition -= 1;
            _balle = Instantiate(bullet, gun.transform.position, Aspirateur.transform.rotation);
            _balle.GetComponent<Rigidbody>().velocity = ((gun.transform.position - Aspirateur.transform.position) * bulletSpeed);
            Destroy(_balle, 10);
            rb.AddForce(-(gun.transform.position - Aspirateur.transform.position)*recul, ForceMode.Impulse);
            StartCoroutine(Bubble(_balle));
            StartCoroutine(shaker.Shake());
            

            //rb.AddForce(Aspirateur.transform.rotation.eulerAngles*suckForce, ForceMode.Acceleration);

        }
    }

    IEnumerator controlBack()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Control = true;
    }

    IEnumerator Bubble(GameObject balle)
    {
        yield return new WaitForSecondsRealtime(.5f);
        //balle.transform.localScale = Vector3.SmoothDamp(balle.transform.localScale, balle.transform.localScale *1000,ref velocity,.5f);
        size = Random.Range(5, 30);
        for (int i = 0; i < size; i++)
        {
            balle.transform.localScale += new Vector3(.05f,.05f,.05f);
        yield return new WaitForSecondsRealtime(.01f);
        }
        
        
        
    }

    void Aim()
    {
        //Aspirateur.transform.eulerAngles=Vector3.SmoothDamp(Aspirateur.transform.eulerAngles, Direction,ref velocity, smoothTime);
        //Aspirateur.transform.eulerAngles = new Vector3(Rx, Ry, 0);
        if (Mathf.Abs(x) > .3f || Mathf.Abs(y) > .3f)
        {
            Aspirateur.transform.eulerAngles = Direction;
        }
    }

    void OnCollisionEnter()
    {
        jump = false;
    }
}
