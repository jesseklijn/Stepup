using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{


    public void SceneTransition(int sceneBuildIndex)
    {
        //Scene scene = SceneManager.GetSceneByName(nameOfScene);
        SceneManager.LoadScene(sceneBuildIndex);
    }


}
