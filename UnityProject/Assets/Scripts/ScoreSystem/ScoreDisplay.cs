﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text scoreDisplay;
    public Text gemScore;
    public void Start()
    {
        DisplayScore(0);
    }

    public void DisplayScore(int score)
    {
        char[] scoreText = score.ToString().ToCharArray();
       
        int amount = 7;

        string display = "";
        for (int i = 0; i < scoreText.Length; i++)
        {
            amount--;    
        }
      
        for (int i = 0; i < amount; i++)
        {
            display += "0";
        }

        display += score.ToString();
        scoreDisplay.text = display;
    }

    public void DisplayGemCount(int score)
    {
        gemScore.text = score.ToString();
    }
}