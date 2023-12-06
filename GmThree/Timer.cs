using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;
    public static bool endTime = false;
    public MoveCat[] moveCats;
    public Movement bananaMove;

    [SerializeField] TextMeshProUGUI countdowntext;

    private void Start()
    {
        endTime = false;
        currentTime = startingTime;
        foreach (MoveCat item in moveCats)
        {
            item.enabled = false;
        }
        bananaMove.enabled = false;
    }
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdowntext.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            currentTime = 0;
            endTime = true;
            this.gameObject.SetActive(false);
            foreach (MoveCat item in moveCats)
            {
                item.enabled = true;
            }
            bananaMove.enabled = true;
        }
    }
}
