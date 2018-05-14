using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishCollider : MonoBehaviour
{

    public ScoreLevelSystem scoreLevelSystem;
    public Canvas canvas;

    AniCTR _aniCTR; //reading ANiCTR script bytanaka
    public GameObject ShunObject;

    //By Tanaka
    void Start()
    {

        //Find AnimatedObject(ShunModel)
        GameObject AnimatedObject = GameObject.Find(ShunObject.name);
        Debug.Log(AnimatedObject);
        _aniCTR = AnimatedObject.GetComponent<AniCTR>();


    }


    private void OnTriggerEnter(Collider other)
    {

        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        _aniCTR.Goal(); //Animation_Shun by tanaka

        scoreLevelSystem.gameObject.SetActive(true);

    }
}
