using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{

    public GameObject[] difficultySelectorGameObjects;
    public GameObject[] minuteSelectorGameObjects;

    public Image[] images; //difficulty
    public Image[] minuteImages; //Minutes
    public string[] sceneNames;
    public int currentDifficultySelect = 0;
    public int currentMinuteSelect = 0;

    public bool minuteSelectorIsActive = false;
    public bool difficultySelectorIsActive = true;

    public AudioSource select, click, finalClick;
    // Use this for initialization
    void Start()
    {
        ChangeDifficultyAlpha(currentDifficultySelect);
        ChangeMinuteAlpha(currentMinuteSelect);
        SetSelector(false);
    }

    // Update is called once per frame
    void Update()
    {
        //higherlevel to lowerlevel
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (difficultySelectorIsActive == true)
            {
                if (ChangeCurrentDifficultySelect(currentDifficultySelect, -1) == true)
                {
                    ChangeDifficultyAlpha(currentDifficultySelect);
                    //Playsound
                    select.Play();
                }
            }
            else if (minuteSelectorIsActive == true)
            {
                if (ChangeCurrentMinuteSelect(currentMinuteSelect, -1) == true)
                {
                    ChangeMinuteAlpha(currentMinuteSelect);
                    //Playsound
                    select.Play();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (difficultySelectorIsActive == true)
            {
                if (ChangeCurrentDifficultySelect(currentDifficultySelect, 1) == true)
                {
                    ChangeDifficultyAlpha(currentDifficultySelect);
                    //Playsound
                    select.Play();
                }
            }
            else if (minuteSelectorIsActive == true)
            {
                if (ChangeCurrentMinuteSelect(currentMinuteSelect, 1) == true)
                {
                    ChangeMinuteAlpha(currentMinuteSelect);
                    //Playsound
                    select.Play();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Continue
            if (difficultySelectorIsActive == true)
            {
                SetSelector(true);
                difficultySelectorIsActive = false;
                minuteSelectorIsActive = true;
                //Playsound
               click.Play();
                return;
            }

            if (minuteSelectorIsActive == true)
            {

                //Playsound
                finalClick.Play();
                GoToRandomStage();
            }


        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (minuteSelectorIsActive == true)
            {
                SetSelector(false);
                currentMinuteSelect = 0;
                minuteSelectorIsActive = false;
                difficultySelectorIsActive = true;
                return;
            }

            if (difficultySelectorIsActive == true)
            {
                
                currentDifficultySelect = 0;
                ChangeDifficultyAlpha(currentDifficultySelect);
            }
            
        }
    }


    void SetSelector(bool b)
    {
        if (b == true)
        {
            //Setactive minute selector
            DifficultySelectorActive(false);
            MinuteSelectorActive(true);

        }
        else
        {
            //Setactive Difficulty selector
            MinuteSelectorActive(false);
            DifficultySelectorActive(true);
        }
    }

    void MinuteSelectorActive(bool b)
    {
        if (b == true)
        {
            for (int i = 0; i < minuteSelectorGameObjects.Length; i++)
            {
                minuteSelectorGameObjects[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < minuteSelectorGameObjects.Length; i++)
            {
                minuteSelectorGameObjects[i].SetActive(false);
            }
        }
    }

    void DifficultySelectorActive(bool b)
    {
        if (b == true)
        {
            
            for (int i = 0; i < difficultySelectorGameObjects.Length; i++)
            {
                difficultySelectorGameObjects[i].SetActive(true);
            }
        }
        else
        {
          
            for (int i = 0; i < difficultySelectorGameObjects.Length; i++)
            {
                difficultySelectorGameObjects[i].SetActive(false);
            }
        }
    }
    void GoToStage(int i)
    {
        SceneManager.LoadScene(sceneNames[i]);
    }
    void GoToRandomStage()
    {
        SceneManager.LoadScene(sceneNames[Random.Range(0, sceneNames.Length - 1)]);
    }
    bool ChangeCurrentDifficultySelect(int i, int increment)
    {
        if (i + increment <= images.Length - 1 && i + increment >= 0)
        {
            currentDifficultySelect += increment;
            return true;
        }

        return false;
    }
    void ChangeDifficultyAlpha(int i)
    {

        for (int j = 0; j < images.Length; j++)
        {
            if (i == j)
            {
                images[j].color = new Color(images[j].color.r, images[j].color.g, images[j].color.b, 1);
            }
            else
            {
                images[j].color = new Color(images[j].color.r, images[j].color.g, images[j].color.b, 0.5F);
            }
        }

    }
    bool ChangeCurrentMinuteSelect(int i, int increment)
    {
        if (i + increment <= minuteImages.Length - 1 && i + increment >= 0)
        {
            Debug.Log("+-");
            currentMinuteSelect += increment;
            return true;
        }

        return false;
    }
    void ChangeMinuteAlpha(int i)
    {

        for (int j = 0; j < minuteImages.Length; j++)
        {
            if (i == j)
            {
                minuteImages[j].color = new Color(minuteImages[j].color.r, minuteImages[j].color.g, minuteImages[j].color.b, 1);
            }
            else
            {
                minuteImages[j].color = new Color(minuteImages[j].color.r, minuteImages[j].color.g, minuteImages[j].color.b, 0.5F);
            }
        }

    }
}
