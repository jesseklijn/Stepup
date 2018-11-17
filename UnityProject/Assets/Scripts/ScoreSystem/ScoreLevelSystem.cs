using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreLevelSystem : MonoBehaviour
{

    //Main overview fields
    public RectTransform mainOverviewRect;
    public float transitionTime = 2.5F;
    public Vector2 startOverviewPos = new Vector2(0, -206);
    public Vector2 endOverviewPos = new Vector2(0, 240);

    public Vector2 startFinishPos = new Vector2(0, -206);
    public Vector2 endFinishPos = new Vector2(0, 240);

    public Vector2 startEndScenePos = new Vector2(0, -206);
    public Vector2 endEndScenePos = new Vector2(0, 240);

    public int timeLimitOverview = 10;
    public int timeLimitHighscore = 10;
    //ScoreOverview
    public Text scoreDisplay;
    public Text sapphireDisplay, rubyDisplay, diamondDisplay;
    public Text sapphireTotalScore, rubyTotalScore, diamondTotalScore;

    //ScoreValues of Gems
    public int sapphireScoreAmount = 1000, rubyScoreAmount = 3000, diamondScoreAmount = 5000;

    //Rank in ScoreOverview
    public Image rankDisplay;
    public RectTransform rankRect;
    public Sprite[] rankSprites;
    public Text[] rankTexts;

    //HighscoreOverview
    public Text[] rankDisplays;
    public Vector2[] yourRankPositionVector2s;
    public RectTransform yourRankGameObject;
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

    //RankData

    public RankData rankData;
    public RankData filteredRank;
    public void OnEnable()
    {
        controller = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        rankData = new RankData();
        rankData.rankList = new List<RankData.RankHolder>();
        LoadRankData();
        SaveRankData("cavestage");

        filteredRank.rankList = rankData.OrderRankByHighestScore("cavestage");
        UpdateDisplay();
        StartCoroutine(MoveTowardsDestination(transitionTime, startFinishPos, endFinishPos, mainOverviewRect, true, false, true));
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
    public bool LoadRankData()
    {
        if (File.Exists((Application.persistentDataPath + "/RankData" + SceneManager.GetActiveScene().name + ".dat")))
        {

            BinaryFormatter bf = new BinaryFormatter();
            Debug.Log("File exists, opening file..");
            FileStream file = File.Open(Application.persistentDataPath + "/RankData" + SceneManager.GetActiveScene().name + ".dat", FileMode.Open);
            rankData = (RankData)bf.Deserialize(file);
            file.Close();
            Debug.Log(rankData.rankList.Count);
            return true;
        }
        return false;
    }

    //TODO
    //Saves all data in data folder. If no datasheet is available, will create data sheet.
    public bool SaveRankData(string levelName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/RankData" + SceneManager.GetActiveScene().name + ".dat");
        RankData.RankHolder rankHolder = new RankData.RankHolder();
        rankHolder.levelName = levelName;
        rankHolder.score = scoreSystem.inGameScore;
        rankData.rankList.Add(rankHolder);
        bf.Serialize(file, rankData);
        file.Close();

        return true;
    }


    //TODO
    //Determines rank from 1st to 5th rank based on score
    public Ranks DetermineRank()
    {
        int placement = 0;
        //If rank 1 is equal to ingamescore
        if (int.Parse(rankTexts[0].text) == scoreSystem.inGameScore)
        {
            return Ranks.First;
        }
        else
        {
            for (int i = 0; i < rankTexts.Length; i++)
            {
                if (rankTexts[i].text.Contains("-------") == false)
                {
                    if (int.Parse(rankTexts[i].text) > scoreSystem.inGameScore)
                    {
                        placement++;
                    }
                }
            }
        }

        //Goes through placements
        switch (placement)
        {
            case 0:
                return Ranks.First;
                break;
            case 1:
                return Ranks.Second;
                break;
            case 2:
                return Ranks.Third;
                break;
            case 3:
                return Ranks.Fourth;
                break;
            case 4:
                return Ranks.Fifth;
                break;
            case 5:
                return Ranks.Fifth;
                break;
            case 6:
                return Ranks.Fifth;
                break;
        }
        //if nothing happens just return lowest rank.
        return Ranks.Fifth;
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
        StartCoroutine(MoveTowardsDestination(movementTime, startPosition, endPosition, rankRect, false, false, false));

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
    public IEnumerator MoveTowardsDestination(float time, Vector3 startValue, Vector3 endValue, RectTransform toMove, bool initial, bool endTheScene, bool cvMetreActivate)
    {


        float t = 0;

        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;
            //Debug.Log(Vector3.Lerp(startValue, endValue, t));
            toMove.anchoredPosition3D = Vector3.Lerp(startValue, endValue, t);
            yield return 0;




        }

        //TODO: Add CV METRE HERE
        if (cvMetreActivate == true)
        {

            //TODO: ADD CV METHOD CALLING HERE
            //TODO: CHANGE TIMER TO WHATEVER TIME YOU THINK IS APPROPIATE
            Debug.Log("CV event fired");
            StartCoroutine(Timer(0, 5));
        }

        if (initial == true)
        {
            AnimateRank();
            StartCoroutine(Timer(0, timeLimitOverview));
        }

        if (endTheScene == true)
        {
            int randomScene = (int)UnityEngine.Random.Range(0, 4);
            controller.timeline.Stop();
            SceneManager.LoadScene(randomScene);

        }
        //Play particleSystem
        //particleSystems[0].Play();



    }

    public void UpdateDisplay()
    {
        //Update first mainscreen
        scoreDisplay.text = scoreSystem.inGameScore.ToString();

        sapphireDisplay.text = scoreSystem.sapphireCount.ToString();
        sapphireTotalScore.text = (scoreSystem.sapphireCount * sapphireScoreAmount).ToString() + " pts";
        rubyDisplay.text = scoreSystem.rubyCount.ToString();
        rubyTotalScore.text = (scoreSystem.rubyCount * rubyScoreAmount).ToString() + " pts";
        diamondDisplay.text = scoreSystem.diamondCount.ToString();
        diamondTotalScore.text = (scoreSystem.diamondCount * diamondScoreAmount).ToString() + " pts";

        if (rankTexts.Length != 0)
        {
            for (int i = 0; i < rankTexts.Length; i++)
            {
                if (rankData.rankList.Count > i)
                {
                    rankTexts[i].text = filteredRank.rankList[i].score.ToString();
                    if (rankTexts[i].text == scoreSystem.inGameScore.ToString())
                    {
                        rankTexts[i].GetComponent<Outline>().effectColor = new Color(0.9F, 0.28F, 0.01F);
                        yourRankGameObject.anchoredPosition = yourRankPositionVector2s[i];
                        if (yourRankGameObject.gameObject.activeSelf == false)
                        {
                            yourRankGameObject.gameObject.SetActive(true);
                        }
                    }
                }
                else
                {
                    rankTexts[i].text = "-------";
                }
            }
        }
        else
        {
            Debug.LogError("ADD RANK TEXTS TO INSPECTOR -> SCORELEVELSYSTEM");
        }

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
                StartCoroutine(MoveTowardsDestination(transitionTime, startOverviewPos, endOverviewPos, mainOverviewRect, false, false, false));
                //Set to true
                hasShownHighscore = true;
                //Restart this timer
                timerRunning = false;
                StartCoroutine(Timer(0, timeLimitHighscore));

            }
            else
            {
                //Start scene transition
                StartCoroutine(MoveTowardsDestination(transitionTime, startEndScenePos, endEndScenePos, mainOverviewRect, false, true, false));

            }
        }
    }




}

[Serializable]
public class RankData
{
    [Serializable]
    public struct Profile
    {
        public string name;
        public int age;
    }
    [Serializable]
    public struct RankHolder
    {
        public string levelName;
        public int score;
        public Profile profile;
        public ScoreLevelSystem.Ranks rank;
    }

    public List<RankHolder> rankList;

    //Filters through profile name and levelname, and then orders by rank from top rank to bottom
    public List<RankHolder> OrderRankByHighestScore(string levelName) //,string profileName
    {
        //Inserts full rank list 
        List<RankHolder> rankListToReturn = rankList;

        //Filters through levelnames
        rankListToReturn = FilterByLevelName(rankListToReturn, levelName);

        //Filters through profilenames
        //rankListToReturn = FilterByProfile(rankListToReturn, profileName);

        rankListToReturn.Sort((s1, s2) => s2.score.CompareTo(s1.score));

        return rankListToReturn;
    }

    //Filters out by profile name
    public List<RankHolder> FilterByProfile(List<RankHolder> rankList, string profileName)
    {
        List<RankHolder> rankListToReturn = new List<RankHolder>();

        for (int i = 0; i < rankList.Count; i++)
        {
            if (rankList[i].profile.name == profileName)
            {
                rankListToReturn.Add(rankList[i]);
            }
        }


        return rankListToReturn;
    }

    //Filters out by levelname
    public List<RankHolder> FilterByLevelName(List<RankHolder> rankList, string levelName)
    {
        List<RankHolder> rankListToReturn = new List<RankHolder>();

        for (int i = 0; i < rankList.Count; i++)
        {
            if (rankList[i].levelName == levelName)
            {
                rankListToReturn.Add(rankList[i]);
            }
        }


        return rankListToReturn;
    }
}