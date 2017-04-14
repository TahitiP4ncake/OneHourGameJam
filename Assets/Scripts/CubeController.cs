using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    private Rigidbody rb;

    public float Speed;
    
    public Collider haut;
    public Collider bas;
    public Collider gauche;
    public Collider droite;

    [HideInInspector]
    public bool CHaut;
    [HideInInspector]
    public bool CBas;
    [HideInInspector]
    public bool CGauche;
    [HideInInspector]
    public bool CDroite; 

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update() {
        if ((Input.GetAxis("Horizontal") != 0) && (CHaut || CBas))
        {
            MoveHorizontal();
        }
        Debug.Log(CBas);
    }
    void MoveHorizontal()
    {
        rb.AddForce(new Vector3(1,0,0)*(Input.GetAxis("Horizontal"))*Speed,ForceMode.Force);
    }



	
}
