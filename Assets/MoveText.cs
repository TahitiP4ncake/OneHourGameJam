using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveText : MonoBehaviour {
    string message;
    Text textComp;
    public float letterPause = 0.2f;

    void Start () {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            /*if (typeSound1 && typeSound2)
                SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
                */
            yield return 0;
            yield return new WaitForSeconds(letterPause*(Random.RandomRange(1f,5f)));
        }
    }
}
