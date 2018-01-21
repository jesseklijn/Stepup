using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreLevelSystem : MonoBehaviour
{

    //Main overview fields
    public RectTransform mainOverviewRect;
    public float transitionTime = 2.5F;
    public Vector2 startOverviewPos = new Vector2(0, -206);
    public Vector2 endOverviewPos = new Vector2(0, 226);

    public Vector2 startFinishPos = new Vector2(0, -206);
    public Vector2 endFinishPos = new Vector2(0, 226);

    public Vector2 startEndScenePos = new Vector2(0, -206);
    public Vector2 endEndScenePos = new Vector2(0, 226);

    public int timeLimitOverview = 10;
    public int timeLimitHighscore = 10;
    //ScoreOverview
    public Text scoreDisplay;
    public Text sapphireDisplay, rubyDisplay, diamondDisplay;
    //Rank in ScoreOverview
    public Image rankDisplay;
    public RectTransform rankRect;
    public Sprite[] rankSprites;

    //HighscoreOverview
    public Text[] rankDisplays;

    //ScoreSystem
    public ScoreSystem scoreSystem;

    //Animation fields
    public Vector3 startPosition = new Vector3(-33, -46, -291);
    public Vector3 endPosition = new Vector3(-33, -46, 0);
    public float fadeTime = 0.3F;
    public float startAlpha = 0;
    public float endAlpha = 1F;
    public float movementTime = 2;

    //Timer fields
    public bool timerRunning = false;
    public bool hasShownHighscore = false;

    public AudioController controller;


    public void OnEnable()
    {
        controller = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        UpdateDisplay();
        StartCoroutine(MoveTowardsDestination(transitionTime, startFinishPos, endFinishPos, mainOverviewRect, true,false));
    }

    public enum Ranks
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,

    }

    //TODO
    //Loads all data from save. If no data, datasheet will be created.
    public int[] LoadRankData()
    {
        return null;
    }

    //TODO
    //Saves all data in data folder. If no datasheet is available, will create data sheet.
    public bool SaveRankData()
    {


        return true;
    }


    //TODO
    //Determines rank from 1st to 5th rank based on score
    public Ranks DetermineRank()
    {

        //Compare scores and determine
        return Ranks.First;
    }

    //Changes the rank image
    public void DisplayRank(Ranks rank)
    {
        Sprite rankToDisplay = rankSprites[4];
        if (rank == Ranks.First)
        {
            rankToDisplay = rankSprites[0];
        }
        else if (rank == Ranks.Second)
        {
            rankToDisplay = rankSprites[1];
        }
        else if (rank == Ranks.Third)
        {
            rankToDisplay = rankSprites[2];
        }
        else if (rank == Ranks.Fourth)
        {
            rankToDisplay = rankSprites[3];
        }
        else if (rank == Ranks.Fifth)
        {
            rankToDisplay = rankSprites[4];
        }

        rankDisplay.sprite = rankToDisplay;
    }

    //Plays an animation of the rank flying in
    public void AnimateRank()
    {
        StartCoroutine(Fade(fadeTime, startAlpha, endAlpha, rankDisplay));
        StartCoroutine(MoveTowardsDestination(movementTime, startPosition, endPosition, rankRect, false, false));

    }

    public IEnumerator Fade(float time, float startValue, float endValue, Image myImage)
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

    }
    public IEnumerator MoveTowardsDestination(float time, Vector3 startValue, Vector3 endValue, RectTransform toMove, bool initial, bool endTheScene)
    {


        float t = 0;

        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;
            Debug.Log(Vector3.Lerp(startValue, endValue, t));
            toMove.anchoredPosition3D = Vector3.Lerp(startValue, endValue, t);
            yield return 0;




        }

        if (initial == true)
        {
            AnimateRank();
            StartCoroutine(Timer(0, timeLimitOverview));
        }
        if (endTheScene == true)
        {
            controller.timeline.Stop();
            SceneManager.LoadScene(0);

        }
        //Play particleSystem
        //particleSystems[0].Play();



    }

    public void UpdateDisplay()
    {
        //Update first mainscreen
        scoreDisplay.text = scoreSystem.inGameScore.ToString();

        sapphireDisplay.text = scoreSystem.sapphireCount.ToString();

        rubyDisplay.text = scoreSystem.rubyCount.ToString();

        diamondDisplay.text = scoreSystem.diamondCount.ToString();



        DisplayRank(DetermineRank());

    }

    public IEnumerator Timer(int time, int limit)
    {
        if (timerRunning == false)
        {
            timerRunning = true;
            float t = 0;
            //Move while time is still below 1
            while (t < 1)
            {
                t += Time.deltaTime / 1;
                yield return 0;
            }
            time += 1;
            if (time != limit)
            {

                timerRunning = false;
                StartCoroutine(Timer(time, limit));
            }
            else if (hasShownHighscore == false)
            {
                //Show highscore (Do animation)
                StartCoroutine(MoveTowardsDestination(transitionTime, startOverviewPos, endOverviewPos, mainOverviewRect, false,false));
                //Set to true
                hasShownHighscore = true;
                //Restart this timer
                timerRunning = false;
                StartCoroutine(Timer(0, timeLimitHighscore));

            }
            else
            {
                //Start scene transition
                StartCoroutine(MoveTowardsDestination(transitionTime, startEndScenePos, endEndScenePos, mainOverviewRect, false, true));

            }
        }
    }




}
