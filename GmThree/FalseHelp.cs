using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseHelp : MonoBehaviour
{
    public GameObject bananaCat;
    float negativePositionX, positivePositionX, negativePositionY, positivePositionY;


    private void Start()
    {
        negativePositionX = bananaCat.transform.position.x - 1;
        positivePositionX = bananaCat.transform.position.x + 1;
        negativePositionY = bananaCat.transform.position.y - 1;
        positivePositionY = bananaCat.transform.position.y + 1;
    }
    private void Update()
    {
        if(Application.isMobilePlatform || bananaCat.transform.position.x < negativePositionX || bananaCat.transform.position.x > positivePositionX || bananaCat.transform.position.y < negativePositionY || bananaCat.transform.position.y > positivePositionY)
        {
            this.gameObject.SetActive(false);
        }
    }
}
