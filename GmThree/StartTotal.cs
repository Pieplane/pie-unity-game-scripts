using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartTotal : MonoBehaviour
{
    public TextMeshProUGUI coinMoney;
    float feeMoney;
    public float currMoney;
    //public GameObject textCoin;
    private void Start()
    {
        feeMoney = 1000;
        FindObjectOfType<AudioManager>().StopPlay("Game");
        FindObjectOfType<AudioManager>().StopPlay("GameTwo");
        FindObjectOfType<AudioManager>().StopPlay("GameThree");
        FindObjectOfType<AudioManager>().StopPlay("Cry");
        FindObjectOfType<AudioManager>().Play("Total");

    }
    public void NewApp()
    {
        currMoney = PlayerPrefs.GetFloat("myMoney", 0f);
        //currMoney = Progress.Instance.PlayerInfo.Coins;
        currMoney += feeMoney;
        PlayerPrefs.SetFloat("myMoney", currMoney);
        //Progress.Instance.PlayerInfo.Coins = currMoney;
        //Progress.Instance.Save();
        coinMoney.text = currMoney.ToString();
    }
}
