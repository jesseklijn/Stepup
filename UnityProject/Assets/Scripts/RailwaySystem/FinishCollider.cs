using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishCollider : MonoBehaviour
{

    public ScoreLevelSystem scoreLevelSystem;
    public Canvas canvas;

    private void OnTriggerEnter(Collider other)
    {

        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
       
        scoreLevelSystem.gameObject.SetActive(true);

    }
}
