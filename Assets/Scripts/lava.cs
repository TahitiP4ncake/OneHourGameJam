using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {
    private bool alive = true;
	// Use this for initialization
	void Start () {
        StartCoroutine(lavaUp());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag =="Player")
        {
            alive = false;
            //Destroy(gameObject);
        }
    }

    IEnumerator lavaUp()
    {
        while (alive)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            transform.position = transform.position + new Vector3(0, Random.Range(0, 0.03f), 0);
        }
    }
}
