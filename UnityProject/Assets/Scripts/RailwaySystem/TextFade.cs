using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {

    public bool isFading = false;
    public Text toFade;

    public float A = 0.3F, B = 1.0F, TIME = 3.0F;

    private void Start()
    {
        StartCoroutine(Fade(A, B, TIME, this.toFade, false));
    }


    public IEnumerator Fade(float AlphaA, float AlphaB, float time, Text toFade, bool fadeIn)
    {
        //Check if character is already moving..

        if (isFading == false)
        {

            isFading = true;
            float alpha = 0;
            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / time;

                if (fadeIn == true)
                {
                    alpha = Mathf.Lerp(AlphaA, AlphaB, t);
                }
                else
                {
                    alpha = Mathf.Lerp(AlphaB, AlphaA, t);

                }
               
                toFade.color = new Color(toFade.color.r, toFade.color.g, toFade.color.b, alpha);
                

                yield return 0;

            }

            //Reset Routine
            isFading = false;
            StartCoroutine(Fade(A, B, TIME, this.toFade, !fadeIn));

        }

    }
}
