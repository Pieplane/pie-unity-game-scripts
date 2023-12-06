using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Pied : MonoBehaviour
{
    public Finish finish;
    public GameObject one;
    public GameObject two;
    public GameObject three;

    public GameObject banana;
    public GameObject happy;
    public GameObject black;

    public GameObject confetti;

    public TextMeshProUGUI text;
    public GameObject textMoney;
    float reward;
    public TextMeshProUGUI allMoney;
    float currentMoney;

    int lvl1;
    int lvl2;
    public GameObject loseCanvas;

    //public CoinStart coin;
    public void Update()
    {
        if (loseCanvas.activeSelf)
        {
            loseCanvas.SetActive(false);
            FindObjectOfType<AudioManager>().StopPlay("Cry");
        }
    }
    private void Start()
    {
        //if (!Progress.Instance.PlayerInfo.Onee)
        //{
        //    Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex - 2;
        //    Progress.Instance.PlayerInfo.Onee = true;
        //    //Progress.Instance.Save();
        //}
        lvl1 = PlayerPrefs.GetInt("LevelReach", 1);
        lvl2 = SceneManager.GetActiveScene().buildIndex - 2;

        if(lvl1 < lvl2)
        {
            PlayerPrefs.SetInt("LevelReach", SceneManager.GetActiveScene().buildIndex - 2);
        }
        //currentMoney = coin.currMoney;
        currentMoney = PlayerPrefs.GetFloat("myMoney", 0f);
        //Progress.Instance.PlayerInfo.Coins = currentMoney;
        //Progress.Instance.Save();
        if (finish.vs[0] == banana.tag)
        {
            confetti.SetActive(true);
            AddCoin(1000f);
            if(finish.vs[1] == happy.tag)
            {
                Instantiate(banana, one.transform.position, one.transform.rotation);
                Instantiate(happy, two.transform.position, two.transform.rotation);
                Instantiate(black, three.transform.position, three.transform.rotation);
            }
            else
            {
                Instantiate(banana, one.transform.position, one.transform.rotation);
                Instantiate(black, two.transform.position, two.transform.rotation);
                Instantiate(happy, three.transform.position, three.transform.rotation);
            }
            
        }
        if(finish.vs[0] == happy.tag)
        {
            if(finish.vs[1] == banana.tag)
            {
                AddCoin(500f);
                Instantiate(happy, one.transform.position, one.transform.rotation);
                Instantiate(banana, two.transform.position, two.transform.rotation);
                Instantiate(black, three.transform.position, three.transform.rotation);
            }
            else
            {
                AddCoin(300f);
                Instantiate(happy, one.transform.position, one.transform.rotation);
                Instantiate(black, two.transform.position, two.transform.rotation);
                Instantiate(banana, three.transform.position, three.transform.rotation);
            }
            
        }
        if(finish.vs[0] == black.tag)
        {
            if(finish.vs[1] == happy.tag)
            {
                AddCoin(300f);
                Instantiate(black, one.transform.position, one.transform.rotation);
                Instantiate(happy, two.transform.position, two.transform.rotation);
                Instantiate(banana, three.transform.position, three.transform.rotation);
            }
            else
            {
                AddCoin(500f);
                Instantiate(black, one.transform.position, one.transform.rotation);
                Instantiate(banana, two.transform.position, two.transform.rotation);
                Instantiate(happy, three.transform.position, three.transform.rotation);
            }
            
        }
        void AddCoin(float money)
        {
            reward = money;
            text.text = reward.ToString();
            currentMoney += reward;
            //Progress.Instance.PlayerInfo.Coins = currentMoney;
            //Progress.Instance.Save();
            StartCoroutine(StartAnim());
            PlayerPrefs.SetFloat("myMoney", currentMoney);
        }
        IEnumerator StartAnim()
        {
            yield return new WaitForSeconds(1f);
            textMoney.SetActive(true);
            StartCoroutine(UpdateAllMoney());
        }
        IEnumerator UpdateAllMoney()
        {
            yield return new WaitForSeconds(1f);
            allMoney.text = currentMoney.ToString();
        }
           
    }
}
