using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownPlayer : MonoBehaviour
{

    public AudioClip[] audioClips;
    public AudioSource source;
    public StepUpSceneManager sceneManager;
    public string[] countdown;
    public Text display;
    bool delay = true;

    public bool isCounting = false;

    public IEnumerator CountDownFrom(int startFrom, AudioClip[] Clips, float timePerClip)
    {
        if(delay)
        {
            yield return new WaitForSeconds(1f);
            delay = false;
        }

        if (isCounting == false)
        {
            isCounting = true;
            float t = 0;
           
            int i = startFrom;
            //Move while time is still below 1
            while (t < 1)
            {

                t += Time.deltaTime / timePerClip;

                yield return 0;

            }
            isCounting = false;
            if (i != -1)
            {
                //playsound
                source.PlayOneShot(Clips[i]);

                //display text
                display.text = countdown[i];
                //repeat
                i--;
                StartCoroutine(CountDownFrom(i, audioClips, 1));
            }
            else
            {
                StartCoroutine(DisableText(display, 0.5F));
                sceneManager.StartGame();
                Singleton.audioController.PlayBGM();
            }
        }
    }
    public IEnumerator DisableText(Text text, float time)
    {
        float t = 0;


        //Move while time is still below 1
        while (t < 1)
        {

            t += Time.deltaTime / time;

            yield return 0;

        }
        text.enabled = false;
    }
}
