using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelector : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public int cursorPosition;

    public AudioClip[] soundSFX;
    public AudioClip backgroundOST;
    public AudioSource backgroundSource;
    public AudioSource soundSFXSource;

    public GameObject[] cursors;
    //Start Game, Settings, LongDistance and Time Attack
    public GameObject[] TextItems;

    public bool GameModeSelectorActive = false;

    void Start()
    {
        PlaySoundtrack();
    }

    void Update()
    {
        //Fires once per 
        if (Input.GetKeyDown(KeyCode.DownArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            UpdateCursor(1);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            UpdateCursor(0);

        }
        //If Enter is pressed.. 
        if (Input.GetKeyDown(KeyCode.Return) == true)
        {

            if (GameModeSelectorActive == false)
            {
                if (cursorPosition == 0)
                {
                    //Activate Gamemode Selection
                    GameModeSelectorActive = true;
                    UpdatePanel(1);
                    PlaySFX(1);
                    return;
                }
                else if (cursorPosition == 1)
                {
                    //TODO: Add settings UI
                    return;
                }
            }

            if (GameModeSelectorActive == true)
            {
                //If ENTER is pressed already, whilst the gamemode menu is open, start a gamemode
                if (cursorPosition == 0)
                {
                    PlaySFX(1);
                    SceneTransition(3);
                    //LongdistanceGamemode load
                }
                else if (cursorPosition == 1)
                {
                    //Choose TimeAttack
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Backspace) == true || Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if (GameModeSelectorActive == true)
            {
                UpdateCursor(0);
                UpdatePanel(0);
                GameModeSelectorActive = false;
                PlaySFX(1);
            }

        }
    }

    //Loads scenes...
    public void SceneTransition(int sceneBuildIndex)
    {
        //Scene scene = SceneManager.GetSceneByName(nameOfScene);
        SceneManager.LoadScene(sceneBuildIndex);
    }

    //Pushes cursor on position based in index [0-1]
    public void UpdateCursor(int cursorPosition)
    {

        if (cursorPosition == 0)
        {

            TextItems[0].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 1);
            TextItems[1].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 0.7F);
            TextItems[2].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 1);
            TextItems[3].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 0.7F);
            cursors[0].SetActive(true);
            cursors[1].SetActive(false);
            //Update the variable so other scripts can also use functionality
            this.cursorPosition = 0;
        }
        else
        {
            TextItems[0].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 0.7F);
            TextItems[1].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 1);
            TextItems[2].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 0.7F);
            TextItems[3].GetComponent<Image>().color = new Color(TextItems[0].GetComponent<Image>().color.r, TextItems[0].GetComponent<Image>().color.g, TextItems[0].GetComponent<Image>().color.b, 1);
            cursors[0].SetActive(false);
            cursors[1].SetActive(true);
            //Update the variable so other scripts can also use functionality
            this.cursorPosition = 1;
        }
        //Play sound after swapping cursor
        PlaySFX(0);
    }

    public void UpdatePanel(int index)
    {
        if (index == 0)
        {
            
            TextItems[0].SetActive(true);
            TextItems[1].SetActive(true);
            TextItems[2].SetActive(false);
            TextItems[3].SetActive(false);
        }
        else if (index == 1)
        {
            TextItems[0].SetActive(false);
            TextItems[1].SetActive(false);
            TextItems[2].SetActive(true);
            TextItems[3].SetActive(true);
        }
    }

    //Plays soundEffect
    public void PlaySFX(int index)
    {
        soundSFXSource.clip = soundSFX[index];
        soundSFXSource.Play();
    }

    //plays soundtrack
    public void PlaySoundtrack()
    {
        backgroundSource.clip = backgroundOST;
        backgroundSource.Play();
    }



}
