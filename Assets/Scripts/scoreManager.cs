using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public int score1;
    public int score2;
    public int score3;
    public int score4;

    public int death;

    public int lose;

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
            // respawn.transform.position = spawner.transform.position;
            // respawn.gameObject.SetActive(true);
            StartCoroutine(Respawn(respawn));
            
            respawns = null;
            //Instantiate(respawn, spawner.transform.position, spawner.transform.rotation);
            // respa
        }
    }
    //IEnumerator respawnTime
    IEnumerator Respawn(GameObject player)
    {
        GameObject _backup = player;
        player.SetActive(false);
        yield return new WaitForSecondsRealtime(.5f);

        _backup.SetActive(true);
        _backup.gameObject.tag = "Player";
        _backup.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _backup.transform.position = spawner.transform.position;
    }
}
