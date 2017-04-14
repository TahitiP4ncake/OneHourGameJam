using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {
    public static int score;

    private Text text;
	
	void Awake () {
        text = GetComponent<Text>();
        score = 0;
        
	}
	
	void Update () {
        
        text.text = "Score : " + score;
        
	}
    
}
