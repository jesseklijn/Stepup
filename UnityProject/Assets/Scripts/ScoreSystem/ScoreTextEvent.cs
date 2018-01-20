using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextEvent : MonoBehaviour
{

    public Text myText;

    public string textToDisplay = "1000";

    public Outline outline;
    public RectTransform scoreToMove;

    public float fadeTime = 1F;
    public float startAlpha = 0;
    public float endAlpha = 0.5F;

    public float movementTime = 2;
    public Vector2 startPosition = new Vector2(0, 0);
    public Vector2 endPosition = new Vector2(-365, 200);

    private bool delete = false;


    private void Start()
    {
        myText.text ="+" +textToDisplay;
        StartCoroutine(MoveTowardsDestination(movementTime, startPosition, endPosition));
        StartCoroutine(Fade(fadeTime, startAlpha, endAlpha, true));
    }

    public IEnumerator MoveTowardsDestination(float time, Vector2 startValue, Vector2 endValue)
    {


        float t = 0;

        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;
            yield return 0;

           scoreToMove.anchoredPosition = Vector2.Lerp(startValue, endValue, t);

            //scale

        }

        Destroy(gameObject, 1);


    }

    public IEnumerator Fade(float time, float startValue, float endValue, bool fadeOut)
    {


        float t = 0;

        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;
            yield return 0;


            myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, Mathf.Lerp(startValue, endValue, t));
            outline.effectColor = new Color(outline.effectColor.r, outline.effectColor.g, outline.effectColor.b, Mathf.Lerp(startValue, endValue, t));

            //scale

        }

        if (fadeOut == true)
            StartCoroutine(Fade(fadeTime, endAlpha, startAlpha, false));
       
        
          
        
    }
}
