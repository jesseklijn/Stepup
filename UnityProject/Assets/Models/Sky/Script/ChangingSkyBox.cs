using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingSkyBox : MonoBehaviour {
    public bool Changing = false;
    float SkyboxBlend = 0;

    void Start () {
        RenderSettings.skybox.SetFloat("_Blend", 0);
    }
	
	
	void Update () {
        if (Changing == false)
        {
            return;
        }

        SkyboxBlend += 0.1f;
        RenderSettings.skybox.SetFloat("_Blend", SkyboxBlend);
        if (SkyboxBlend > 1.0f)
        {
            Changing = false;
        }
    }
}
