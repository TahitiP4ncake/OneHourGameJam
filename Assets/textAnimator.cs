using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//je dois tester ça sur une lettre d'une fenetre de texte 
//et faire la boucle de for pour l'animer
//faudrait essayer les texte à la hotline miami

public class textAnimator : MonoBehaviour {
    /*
    public float x;
    public float y;
    public float z;
    */
    [Space]
    [Header("Letter path")]
    public AnimationCurve x;
    public AnimationCurve y;
    public AnimationCurve z;
    [Space]
    public AnimationCurve anim;
    private Keyframe[] ks;
    private Vector3 origine;
    void Start () {
        origine = transform.position;
        //StartCoroutine(letterPath());
        ks = new Keyframe[50];
        int i = 0;
        while (i < ks.Length)
        {
            ks[i] = new Keyframe(i, i);
            i++;
        }
        //anim = new AnimationCurve(ks);
    }
	

	void Update () {
        transform.position = new Vector3(x.Evaluate(Time.time)+origine.x, y.Evaluate(Time.time)+origine.y, z.Evaluate(Time.time)+origine.z);
        // transform.position = new Vector3(x, 0, 0);
    }
/*
    IEnumerator letterPath()
    {

    }
    */
}
