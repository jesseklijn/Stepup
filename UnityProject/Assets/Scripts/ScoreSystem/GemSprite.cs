using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemSprite : MonoBehaviour
{

    public Image myImage;

    public float fadeTime = 1F;
    public float startAlpha = 0;
    public float endAlpha = 1F;

    public float movementTime = 2;
    public Vector2 startPosition = new Vector2(0, 0);
    public Vector2 endPosition = new Vector2(-365, 200);


    public RectTransform gemToMove;


    private void Awake()
    {
        StartCoroutine(FadeIn(fadeTime, startAlpha, endAlpha));

    }

    public IEnumerator FadeIn(float time, float startValue, float endValue)
    {


        float t = 0;

        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;
            yield return 0;

           
            myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, Mathf.Lerp(startValue, endValue, t));
            //scale

        }

        //After fading in, start moving to destination
        StartCoroutine(MoveTowardsDestination(movementTime, startPosition, endPosition));

    }
    public IEnumerator MoveTowardsDestination(float time, Vector2 startValue, Vector2 endValue)
    {


        float t = 0;

        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;
            yield return 0;

            gemToMove.anchoredPosition = Vector2.Lerp(startValue, endValue, t);
           
            //scale

        }

        //After fading in, start moving to destination


    }


}
