using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAnimation : MonoBehaviour
{

    public Vector3[] fallPoints;
    public GameObject gemObject;
    public int iterator = 0;

    private int fallDirection = 1;
    // Use this for initialization
    void Start()
    {
        //Start falling gem
        OnGemFall();
        if (Random.Range(0, 10) > 5)
        {
            fallDirection = -fallDirection;
        };
    }

    // Update is called once per frame
    void OnGemFall()
    {

        //start falling
        StartCoroutine(FallGem(0, 0.3F));
        StartCoroutine(WobbleGem(0.2F, 35));

    }

    public IEnumerator WobbleGem(float time, int direction)
    {
        Vector3 oldEuler = transform.eulerAngles;
    

        //TODO: Add sound effect to wobbling
        float t = 0;
        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;


            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Lerp(oldEuler.z, oldEuler.z + direction, t));
            yield return 0;

        }



        StartCoroutine(WobbleGem(Random.Range(0.3F, 0.6F), -direction));


    }
    public IEnumerator FallGem(int step, float time)
    {
        Vector3 oldPos = transform.position;
        Vector3 newPos = Vector3.zero;

        //TODO: Add sound effect to falling
        float t = 0;
        //Move while time is still below 1

        while (t < 1)
        {

            t += Time.deltaTime / time;

            newPos.x = Mathf.Lerp(oldPos.x, oldPos.x + fallPoints[step].x * fallDirection, t);
            newPos.y = Mathf.Lerp(oldPos.y, oldPos.y + fallPoints[step].y, t);
            newPos.z = Mathf.Lerp(oldPos.z, oldPos.z + fallPoints[step].z * fallDirection, t);
            transform.position = newPos;
            yield return 0;

        }


        //Reset Routine
        if (step == fallPoints.Length - 1)
        {
            Destroy(gameObject);
        }
        else
        {

            StartCoroutine(FallGem(step + 1, 0.5F));
        }

    }
}
