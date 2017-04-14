using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class chronometre : MonoBehaviour {
    public static int chrono;

    private Text text;
    private int secondes = 0;
    private int minutes = 0;
    void Awake()
    {
        text = GetComponent<Text>();
        chrono = 0;
        StartCoroutine(time());
    }

    void Update()
    {
        
        if(secondes==60)
        {
            secondes = 0;
            minutes += 1;

        }
        text.text = minutes +" : "+ secondes;

    }
    IEnumerator time()
    {
        yield return new WaitForSecondsRealtime(1f);
        chrono += 1;
        secondes += 1;
        StartCoroutine(time());
    }
}