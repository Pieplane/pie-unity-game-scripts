using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class HalpMe : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowReward();
    //VideoSkip videoSkip;

    public static bool halpwant = false;
    public static bool halpwant2 = false;
    bool hlp = false;

    private void Start()
    {
        halpwant = false;
        hlp = true;
        //videoSkip = FindObjectOfType<VideoSkip>();
    }
    private void Update()
    {
        if (LinesDrawer.alreadyDraw && hlp)
        {
            this.gameObject.SetActive(false);
            hlp = false;
            Debug.Log("hlp false");
        }
    }

    public void Haalp()
    {
        halpwant = true;
        halpwant2 = true;
        Time.timeScale = 0;
        ShowReward();
        //videoSkip.StartLevelAfterVideo();
    }
}
