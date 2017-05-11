using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraEffect : MonoBehaviour {

    //shake
    public float duration = .1f;
    public float magnitude = 1;
    private bool isShaking;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = transform.position;
        if (!isShaking)
        {
            isShaking = true;
            while (elapsed < duration)
            {

                elapsed += Time.deltaTime;

                float percentComplete = elapsed / duration;
                float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

                // map value to [-1, 1]
                float x = Random.value * 2.0f - 1.0f;
                float y = Random.value * 2.0f - 1.0f;
                x *= magnitude * damper;
                y *= magnitude * damper;

                transform.position = new Vector3(originalCamPos.x + x, originalCamPos.y + y, originalCamPos.z);

                yield return null;
            }
            isShaking = false;
        }
        transform.position = originalCamPos;
    }
}
