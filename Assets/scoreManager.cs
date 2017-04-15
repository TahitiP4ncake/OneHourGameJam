using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public int score1;
    public int score2;
    public int score3;
    public int score4;

    public GameObject spawner;
    public GameObject[] respawns;
    public List<GameObject> players = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        respawns = GameObject.FindGameObjectsWithTag("Respawn");
        /*
        if (respawns == null)
        {
            //respawns = GameObject.FindGameObjectsWithTag("Respawn");
            respawns = GameObject.FindGameObjectsWithTag("Respawn");
        }
        */
        //Debug.Log(respawns);
        foreach (GameObject respawn in respawns)
        {

            //Debug.Log("oui");
            respawn.transform.position = spawner.transform.position;
           // respawn.gameObject.SetActive(true);
            respawn.gameObject.tag = "Player";
            respawn.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            respawns = null;
            //Instantiate(respawn, spawner.transform.position, spawner.transform.rotation);
            // respa
        }
    }
    //IEnumerator respawnTime
}
