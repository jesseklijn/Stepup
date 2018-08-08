using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelector : MonoBehaviour
{

    public Image[] images;
    public string[] sceneNames;
    private int currentStageSelect = 0;

    // Use this for initialization
    void Start()
    {
        ChangeAlpha(currentStageSelect);
    }

    // Update is called once per frame
    void Update()
    {
        //higherlevel to lowerlevel
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (ChangeCurrentSelect(currentStageSelect, -1) == true)
            {
                ChangeAlpha(currentStageSelect);
                //TODO:playsound
            }
           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (ChangeCurrentSelect(currentStageSelect, 1) == true)
            {
                ChangeAlpha(currentStageSelect);
                //TODO:playsound
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GoToRandomStage();
        }

    }

    void GoToStage(int i)
    {
       SceneManager.LoadScene(sceneNames[i]);
    }
    void GoToRandomStage()
    {
        SceneManager.LoadScene(sceneNames[Random.Range(0,sceneNames.Length-1)]);
    }
    bool ChangeCurrentSelect(int i, int increment)
    {
        if (i + increment <= images.Length - 1 && i + increment >= 0)
        {
            currentStageSelect += increment;
            return true;
        }

        return false;
    }
    void ChangeAlpha(int i)
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
}
