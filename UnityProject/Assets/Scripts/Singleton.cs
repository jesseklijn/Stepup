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

    static CinematicController _cinematicController;
    public static CinematicController cinematicController
    {
        get { return _cinematicController; }
        set { _cinematicController = value; }
    }

    void Awake()
    {        
        if (_audioController == null)
        {
            _audioController = GetComponentInChildren<AudioController>();
            _audioController.transform.SetParent(null);
            //DontDestroyOnLoad(_audioController.gameObject);
        }
        else
        {
            AudioController currentAudioController = GetComponentInChildren<AudioController>();
            Destroy(currentAudioController.gameObject);
        }

        if (_cinematicController == null)
        {
            _cinematicController = GetComponentInChildren<CinematicController>();
            _cinematicController.transform.SetParent(null);
            //DontDestroyOnLoad(_cinematicController.gameObject);
        }
        else
        {
            CinematicController currentCinematicController = GetComponentInChildren<CinematicController>();
            Destroy(currentCinematicController.gameObject);
        }

        Destroy(gameObject);
    }
}