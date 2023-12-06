using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinStart : MonoBehaviour
{
    public TextMeshProUGUI allMoney;
    public float currMoney;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        currMoney = PlayerPrefs.GetFloat("myMoney", 0f);
        //currMoney = Progress.Instance.PlayerInfo.Coins;
        allMoney.text = currMoney.ToString();
    }
}
