using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public float degreesToRotate = 180;
    public float timeItTakes = 10;

	// Use this for initialization
	void Start () {
        StartCoroutine(CountDownFrom(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.y + degreesToRotate, timeItTakes));
    }

    public IEnumerator CountDownFrom(float startRotation, float endRotation, float timePerClip)
    {
        float t = 0;

      
        while (t < 1)
        {

            t += Time.deltaTime / timePerClip;

            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, Mathf.LerpAngle(startRotation, endRotation, t),transform.rotation.eulerAngles.z);

            yield return 0;

        }

      
            StartCoroutine(CountDownFrom(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.y+ degreesToRotate, timeItTakes));
        

    }
}
