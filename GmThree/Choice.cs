using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public GameObject[] view;
    public GameObject[] mark;

    private void Start()
    {
        Buy.choiceBanan = true;
        Buy.skate = false;
        Buy.samokat = false;
        Buy.skuter = false;
        view[0].SetActive(true);
        view[1].SetActive(false);
        view[2].SetActive(false);
        view[3].SetActive(false);
    }
    public void None()
    {
        view[0].SetActive(true);
        view[1].SetActive(false);
        view[2].SetActive(false);
        view[3].SetActive(false);
        Buy.choiceBanan = true;
        Buy.skate = false;
        Buy.samokat = false;
        Buy.skuter = false;
        mark[0].SetActive(true);
        mark[1].SetActive(false);
        mark[2].SetActive(false);
        mark[3].SetActive(false);
        //Progress.Instance.PlayerInfo.Banana = true;
        //Progress.Instance.PlayerInfo.ChoiceBanana = true;
        //Progress.Instance.PlayerInfo.ChoiceSkate = false;
        //Progress.Instance.PlayerInfo.ChoiceSkuter = false;
        //Progress.Instance.PlayerInfo.ChoiceSamokat = false;
        //Progress.Instance.Save();

    }
    public void ChoiceSkateboard()
    {
        view[0].SetActive(false);
        view[1].SetActive(true);
        view[2].SetActive(false);
        view[3].SetActive(false);
        if (Buy.yesskate)
        {
            //Progress.Instance.PlayerInfo.Banana = false;
            Buy.choiceBanan = false;
            Buy.skate = true;
            Buy.samokat = false;
            Buy.skuter = false;
            //Progress.Instance.PlayerInfo.ChoiceBanana = false;
            //Progress.Instance.PlayerInfo.ChoiceSkate = true;
            //Progress.Instance.PlayerInfo.ChoiceSkuter = false;
            //Progress.Instance.PlayerInfo.ChoiceSamokat = false;
            //Progress.Instance.Save();
            mark[0].SetActive(false);
            mark[1].SetActive(true);
            mark[2].SetActive(false);
            mark[3].SetActive(false);
        }
    }
    public void ChoiceSamokat()
    {
        view[0].SetActive(false);
        view[1].SetActive(false);
        view[2].SetActive(true);
        view[3].SetActive(false);
        if (Buy.yessamokat)
        {
            //Progress.Instance.PlayerInfo.Banana = false;
            Buy.choiceBanan = false;
            Buy.skate = false;
            Buy.samokat = true;
            Buy.skuter = false;
            //Progress.Instance.PlayerInfo.ChoiceBanana = false;
            //Progress.Instance.PlayerInfo.ChoiceSkate = false;
            //Progress.Instance.PlayerInfo.ChoiceSkuter = false;
            //Progress.Instance.PlayerInfo.ChoiceSamokat = true;
            //Progress.Instance.Save();
            mark[0].SetActive(false);
            mark[1].SetActive(false);
            mark[2].SetActive(true);
            mark[3].SetActive(false);
        }
    }
    public void ChoiceSkuter()
    {
        view[0].SetActive(false);
        view[1].SetActive(false);
        view[2].SetActive(false);
        view[3].SetActive(true);
        if (Buy.yesskuter)
        {
            //Progress.Instance.PlayerInfo.Banana = false;
            Buy.choiceBanan = false;
            Buy.skate = false;
            Buy.samokat = false;
            Buy.skuter = true;
            //Progress.Instance.PlayerInfo.ChoiceBanana = false;
            //Progress.Instance.PlayerInfo.ChoiceSkate = false;
            //Progress.Instance.PlayerInfo.ChoiceSkuter = true;
            //Progress.Instance.PlayerInfo.ChoiceSamokat = false;
            //Progress.Instance.Save();
            mark[0].SetActive(false);
            mark[1].SetActive(false);
            mark[2].SetActive(false);
            mark[3].SetActive(true);
        } 
    }
}
