using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBanana : MonoBehaviour
{
    public Slider sliderBanana;
    public GameObject bananaCat;
    public GameObject finish;
    float positionBananaX;
    float positionFinishX;
    float currentPosition;

    private void Start()
    {
        positionBananaX = bananaCat.GetComponent<Transform>().position.x;
        positionFinishX = finish.GetComponent<Transform>().position.x;
        sliderBanana.minValue = positionBananaX;
        sliderBanana.maxValue = positionFinishX;
    }
    private void Update()
    {
        if(bananaCat == null)
        {
            Debug.Log("Не существуцет банана кота на сцене");

        }
        else
        {
            currentPosition = bananaCat.transform.position.x;
            sliderBanana.value = currentPosition;
            //Debug.Log(currentPosition);
        }

    }
}
