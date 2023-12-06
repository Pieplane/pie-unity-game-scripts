using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;
    public static bool endTime = false;
    bool newhalp;

    [SerializeField] TextMeshProUGUI countdowntext;

    private void Start()
    {
        endTime = false;
        currentTime = startingTime;
        HalpMe.halpwant2 = false;
    }
    private void Update()
    {
        if (!HalpMe.halpwant2)
        {
            currentTime -= 1 * Time.deltaTime;
            countdowntext.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;
                endTime = true;
                this.gameObject.SetActive(false);
            }
        }
        if (HalpMe.halpwant2)
        {
            currentTime = 1 * Time.deltaTime;
            countdowntext.text = currentTime.ToString("0");
            //Debug.Log("Нажата подсказка");
        }
    }
}
