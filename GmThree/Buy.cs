using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public TextMeshProUGUI allMoney;
    public static bool choiceBanan;
    public static bool skate;
    public static bool samokat;
    public static bool skuter;

    public static bool yesskate;
    public static bool yessamokat;
    public static bool yesskuter;

    public Button[] buttonsBuy;
    public GameObject[] mark;
    float currentMoney;
    float priceSkateboard = 8000;
    float priceSamokat = 20000;
    float priceSkuter = 50000;

    int yupiSkate;
    int yupiSamokat;
    int yupiSkuter;

    private void Start()
    {
        currentMoney = PlayerPrefs.GetFloat("myMoney", 0f);
        yupiSkate = PlayerPrefs.GetInt("HaveSkate", 0);
        yupiSamokat = PlayerPrefs.GetInt("HaveSamokat", 0);
        yupiSkuter = PlayerPrefs.GetInt("HaveSkuter", 0);
        //currentMoney = Progress.Instance.PlayerInfo.Coins;
        //...Деактивирует кнопки купить если предмет уже куплен
        if (yupiSkate == 1)
        {
            buttonsBuy[0].interactable = false;
            yesskate = true;
        }
        if (yupiSamokat == 1)
        {
            buttonsBuy[1].interactable = false;
            yessamokat = true;
        }
        if (yupiSkuter == 1)
        {
            buttonsBuy[2].interactable = false;
            yesskuter = true;
        }
        //yesskate = false;
        //yessamokat = false;
        //yesskuter = false;
    }

    //public void ChoiceBananaCat()
    //{
    //    yesBanan = true;
    //    choiceBanan = true;
    //    skate = false;
    //    samokat = false;
    //    skuter = false;
    //    mark[0].SetActive(true);
    //    mark[1].SetActive(false);
    //    mark[2].SetActive(false);
    //    mark[3].SetActive(false);
    //}
    public void BuySkateBoard()
    {
        if (currentMoney >= priceSkateboard)
        {
            PlayerPrefs.SetInt("HaveSkate", true ? 1 : 0);
            yesskate = true;
            choiceBanan = false;
            samokat = false;
            skuter = false;
            skate = true;
            //Progress.Instance.PlayerInfo.Skate = true;
            //Progress.Instance.PlayerInfo.Banana = false;
            //Progress.Instance.PlayerInfo.ChoiceBanana = false;
            //Progress.Instance.PlayerInfo.ChoiceSamokat = false;
            //Progress.Instance.PlayerInfo.ChoiceSkuter = false;
            //Progress.Instance.PlayerInfo.ChoiceSkate = true;
            mark[0].SetActive(false);
            mark[1].SetActive(true);
            mark[2].SetActive(false);
            mark[3].SetActive(false);
            currentMoney -= priceSkateboard;
            //Progress.Instance.PlayerInfo.Coins = currentMoney;
            //Progress.Instance.Save();
            PlayerPrefs.SetFloat("myMoney", currentMoney);
            allMoney.text = currentMoney.ToString();
            buttonsBuy[0].interactable = false;
        }
        else
            return; 
    }
    public void BuySamokat()
    {
        if (currentMoney >= priceSamokat)
        {
            PlayerPrefs.SetInt("HaveSamokat", true ? 1 : 0);
            yessamokat = true;
            choiceBanan = false;
            skate = false;
            skuter = false;
            samokat = true;
            mark[0].SetActive(false);
            mark[1].SetActive(false);
            mark[2].SetActive(true);
            mark[3].SetActive(false);
            currentMoney -= priceSamokat;
            PlayerPrefs.SetFloat("myMoney", currentMoney);
            allMoney.text = currentMoney.ToString();
            buttonsBuy[1].interactable = false;
            //Progress.Instance.PlayerInfo.Samokat = true;
            //Progress.Instance.PlayerInfo.Banana = false;
            //Progress.Instance.PlayerInfo.ChoiceBanana = false;
            //Progress.Instance.PlayerInfo.ChoiceSkate = false;
            //Progress.Instance.PlayerInfo.ChoiceSkuter = false;
            //Progress.Instance.PlayerInfo.ChoiceSamokat = true;
            //Progress.Instance.PlayerInfo.Coins = currentMoney;
            //Progress.Instance.Save();
        }
        else
            return;
    }
    public void BuySkuter()
    {
        if (currentMoney >= priceSkuter)
        {
            PlayerPrefs.SetInt("HaveSkuter", true ? 1 : 0);
            yesskuter = true;
            choiceBanan = false;
            skate = false;
            samokat = false;
            skuter = true;
            mark[0].SetActive(false);
            mark[1].SetActive(false);
            mark[2].SetActive(false);
            mark[3].SetActive(true);
            currentMoney -= priceSkuter;
            PlayerPrefs.SetFloat("myMoney", currentMoney);
            allMoney.text = currentMoney.ToString();
            buttonsBuy[2].interactable = false;
            //Progress.Instance.PlayerInfo.Skuter = true;
            //Progress.Instance.PlayerInfo.Banana = false;
            //Progress.Instance.PlayerInfo.ChoiceBanana = false;
            //Progress.Instance.PlayerInfo.ChoiceSkate = false;
            //Progress.Instance.PlayerInfo.ChoiceSkuter = true;
            //Progress.Instance.PlayerInfo.ChoiceSamokat = false;
            //Progress.Instance.PlayerInfo.Coins = currentMoney;
            //Progress.Instance.Save();
        }
        else
            return;
    }
}
