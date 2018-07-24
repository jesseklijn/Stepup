using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotator : MonoBehaviour
{

    public int speed;
    public bool forward;
    public RectTransform rectTransform;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var angles = rectTransform.rotation.eulerAngles;
        if (forward == true)
            angles.z += Time.deltaTime * speed;
        else
        {
            angles.z -= Time.deltaTime * speed;
        }
        rectTransform.rotation = Quaternion.Euler(angles);
    }
}
