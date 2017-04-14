// je suis trop teubé putain, 
// je vais el refaire avec des raycast :3
//plus simple, moins de controller et plus de tweaking sur la transition de la gravité :|



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Vector3 gravityEffect;

    public float gravityAngle;
    public float gravityForce;
    public float speed;
    public float jumpForce;
    public float maxSpeed = 5f;

    private Vector3 velocity = Vector3.zero;
    private bool grounded;
    private Vector3 moveDirection;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        //la gravité  qui va changer en fonction du cube sur lequel on se tient

        gravityEffect = Quaternion.Euler(0, 0, gravityAngle) * Vector3.down;


        rb.AddForce(gravityEffect * gravityForce, ForceMode.Force);

        Debug.Log(moveDirection);
        //fin de la gravité

        if (!(Input.GetAxis("Horizontal") == 0))
        {
            Move();
        }
        if (Input.GetButtonDown("Vertical") && grounded)
        {
            Jump();
            grounded = false;
        }
    }

    void FixedUpdate()
    {
        
       
        
    }


    void Move()
    {
        moveDirection = Quaternion.Euler(0,0,gravityAngle + 90)*Vector3.down;
        //rb.AddForce(new Vector3(Input.GetAxis("Horizontal"),0,0) * speed, ForceMode.Force);
         rb.AddForce(Input.GetAxis("Horizontal")* speed*moveDirection, ForceMode.Force);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, rb.velocity.normalized * maxSpeed, ref velocity, 0.5f);
        }
    }
    void Jump()
    {
        rb.AddForce(-gravityEffect * jumpForce, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    { 
        if (!(collision.collider.tag == "Player"))
        {
            grounded = true;
        }
        /*
       if(collision.collider.tag=="red")
        {
            gravityAngle = 0;
        }
        if (collision.collider.tag == "blue")
        {
            gravityAngle = 90;
        }
        if (collision.collider.tag == "yellow")
        {
            gravityAngle = 180;
        }
        if (collision.collider.tag == "green")
        {
            gravityAngle = 270;
        }
        */
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "red")
        {
            gravityAngle = 0;
        }
        if (collision.GetComponent<Collider>().tag == "blue")
        {
            gravityAngle = 90;
        }
        if (collision.GetComponent<Collider>().tag == "yellow")
        {
            gravityAngle = 180;
        }
        if (collision.GetComponent<Collider>().tag == "green")
        {
            gravityAngle = 270;
        }
    }

}
//vector = Quaternion.Euler(0, -45, 0) * vector;