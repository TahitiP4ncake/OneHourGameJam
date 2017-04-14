using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasDetection : MonoBehaviour {

    public GameObject Player;
    
     
	void Start () {
        Player = GameObject.Find("CubeCOntroller");

    }
	
	
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {

        Player.GetComponent<CubeController>().CBas = true;
    }
    void OnTriggerExit(Collider other)
    {
        Player.GetComponent<CubeController>().CBas = false;
    }
}
