using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour {
    public Score scoreManager;

    private int death;

    private Vector3 originScale;
    void Start () {
        scoreManager = Score.Instance;
        originScale = transform.localScale;
    }
	
	
	void Update () {

        death = scoreManager.death;

        CheckSize();

    }

    void CheckSize()
    {
        transform.localScale = originScale + new Vector3(death, death, death);

    }
}
