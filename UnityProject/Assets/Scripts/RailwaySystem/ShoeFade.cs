using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoeFade : MonoBehaviour {

    public bool isFading = false;


    public float scalingA = 1.0F, scalingB = 1.3F, TIME = 2.0F;

 
    private void OnEnable()
    {
        isFading = false;
        StartCoroutine(Fade(scalingA, scalingB, TIME, true));
    }


    public IEnumerator Fade(float scaleA, float scaleB, float time, bool fadeIn)
    {
        //Check if character is already moving..

        if (isFading == false)
        {

            isFading = true;
            float scale = 0;
            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / time;

                if (fadeIn == true)
                {
                    scale = Mathf.Lerp(scaleA, scaleB, t);
                }
                else
                {
                    scale = Mathf.Lerp(scaleB, scaleA, t);

                }

                transform.localScale = new Vector3(scale, scale, scale);
                

                yield return 0;

            }

            //Reset Routine
            isFading = false;
            StartCoroutine(Fade(scalingA, scalingB, TIME, !fadeIn));

        }

    }
}
