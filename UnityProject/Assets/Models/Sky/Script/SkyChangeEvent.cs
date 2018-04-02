using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class SkyChangeEvent : MonoBehaviour {
    public GameObject Player;
    public float ChangePosZ;
    public GameObject Dandelion;
    private ParticleSystem _Dandelion;
    bool Passing = false;

    public GameObject ChangingSkyBox;
    private ChangingSkyBox _ChangingSkyBox;

    //public Camera MainCam;
    public GameObject MainCam;
    private PostProcessingBehaviour behavior;
    private DepthOfFieldModel.Settings depthsetting;

	void Start () {
        _ChangingSkyBox = ChangingSkyBox.GetComponent<ChangingSkyBox>();
        _Dandelion = Dandelion.GetComponent<ParticleSystem>();

        behavior = MainCam.GetComponent<PostProcessingBehaviour>();
        depthsetting = behavior.profile.depthOfField.settings;
        depthsetting.focusDistance = 4.2f;
        behavior.profile.depthOfField.settings = depthsetting;
    }
	
	
	void Update () {
        
        if (Passing)
        {
            return;
        }

        if (Player.transform.position.z > ChangePosZ)
        {
            ChangeEvent();
        }
	}

    void ChangeEvent()
    {
        //_Dandelion.Play();
        _ChangingSkyBox.Changing = true;
        Dandelion.SetActive(true);
        depthsetting.focusDistance = 6.0f;
        behavior.profile.depthOfField.settings = depthsetting;
        //_Dandelion.Play();
        Debug.Log(_Dandelion.isPlaying);
        Passing = true;
    }
    
}
