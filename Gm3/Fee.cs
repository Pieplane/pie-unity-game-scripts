using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Fee : MonoBehaviour
{
    //public TextMeshProUGUI coinMoney;
    //float feeMoney;
    //public float currMoney;
    public GameObject textCoin;
    //public GameObject button;

    [DllImport("__Internal")]
    private static extern void ShowReward();

    private void Start()
    {
        //float curr = float.Parse(winMoney.text);
        //feeMoney = 1000;
        //this.gameObject.SetActive(false);
        //Invoke("CheckWinMoney", 0.1f);
    }
    public void CheckWinMoney()
    {
        //this.gameObject.SetActive(true);
        //feeMoney = 1000;
        //Debug.Log("Выигрыш: " + feeMoney);
    }
    public void AppMoney()
    {
        ShowReward();
        //currMoney = PlayerPrefs.GetFloat("myMoney", 0f);
        //currMoney = Progress.Instance.PlayerInfo.Coins;
        //currMoney += feeMoney;
        //PlayerPrefs.SetFloat("myMoney", currMoney);
        //Progress.Instance.PlayerInfo.Coins = currMoney;
        //Progress.Instance.Save();
        //coinMoney.text = currMoney.ToString();
        this.gameObject.SetActive(false);
        textCoin.SetActive(false);
    }
}
