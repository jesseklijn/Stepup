using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour
{

    static AudioController _audioController;
    public static AudioController audioController
    {
        get { return _audioController; }
        set { _audioController = value; }
    }

    void Awake()
    {        
        if (_audioController == null)
        {
            _audioController = GetComponentInChildren<AudioController>();
            _audioController.transform.SetParent(null);
            DontDestroyOnLoad(_audioController.gameObject);
        }
        else
        {
            AudioController currentAudioController = GetComponentInChildren<AudioController>();
            Destroy(currentAudioController.gameObject);
        }

        Destroy(gameObject);
    }
}