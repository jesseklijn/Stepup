using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

public class AudioController : MonoBehaviour
{
    public AudioSource[] allSfx, allBgm;
    public float bgmVolume, sfxVolume;
    List<GameObject> allAudio = new List<GameObject>();

    void Start()
    {
        GetVolumes();
    }


    public void GetVolumes()
    {
        bgmVolume = 1; // TEMP
        sfxVolume = 1; // TEMP
    }

    // public void ChangeSFXVolume(float volume)
    // {
    //     sfxVolume = volume;
    // }

    public void PlaySFX(string song, GameObject source, bool followObject = false, bool pitched = false)
    {
        AudioSource toPlay = null;
        for (int i = 0; i < allSfx.Length; i++)
        {
            if (song == allSfx[i].name)
            {
                toPlay = allSfx[i];
                break;
            }
        }
        if (toPlay == null)
            return;
        GameObject soundObject = null;
        if (!followObject)
        {
            soundObject = (GameObject)Instantiate(toPlay.gameObject, source.transform.position, Quaternion.identity);
        }
        else
        {
            soundObject = (GameObject)Instantiate(toPlay.gameObject, source.transform, false);
        }
        soundObject.name = song;
        AudioSource sound = soundObject.GetComponent<AudioSource>();

        if (pitched)
        {
            sound.pitch = Random.Range(0.8f, 1.2f);
        }

        sound.PlayOneShot(sound.clip, sound.volume = Remap(sound.volume, 0, 1, 0, sfxVolume));
        allAudio.Add(soundObject);
        Stop(song, sound.clip.length);
    }

    public void Stop(string song, float delay = 0)
    {
        StartCoroutine(StopFinal(song, delay));
    }

    IEnumerator StopFinal(string song, float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < allAudio.Count; i++)
        {
            if(allAudio[i] == null)
            {
                allAudio.RemoveAt(i);
                i--;
                continue;
            }
            if (allAudio[i].name == song)
            {
                if (allAudio[i].activeInHierarchy)
                {
                    Destroy(allAudio[i].gameObject);
                    allAudio.RemoveAt(i);
                }
                break;
            }
        }
    }

    public void PlayBGM(string song, bool stopOldBgm = true)
    {
        AudioSource toPlay = null;
        for (int i = 0; i < allBgm.Length; i++)
        {
            if (song == allBgm[i].name)
            {
                toPlay = allBgm[i];
                break;
            }
        }

        AudioSource[] allSources = GetComponentsInChildren<AudioSource>();

        if (stopOldBgm)
        {
            
            for (int i = 0; i < allSources.Length; i++)
            {
                if (allSources[i].name == song)
                    return;
                Stop(allSources[i].name);
            }
        }
        GameObject soundObject = (GameObject)Instantiate(toPlay.gameObject, gameObject.transform, false);
        soundObject.name = toPlay.name;
        allAudio.Add(soundObject);
        AudioSource sound = soundObject.GetComponent<AudioSource>();
        sound.Play();
        sound.volume = Remap(sound.volume, 0, 1, 0, bgmVolume);
    }

    public static float Remap(float value, float oldMin, float oldMax, float newMin, float newMax)
    {
        return (value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin;
    }
}
