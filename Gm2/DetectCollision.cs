using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    //Скрипт для определения защищен игрок от падения на него платформы или нет
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public float findWin = 0f;
    public bool youLose = false;

    public Animator anim;
    public bool needWin = false;
    //public bool needAdv = false;
    AudioManager audioManagerInstance;


    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
        if (needWin)
        {
            Invoke("Win", findWin);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !winCanvas.activeSelf)
        {
            Debug.Log("Detect Collision! You Lose.");
            if (audioManagerInstance != null)
            {
                FindObjectOfType<AudioManager>().StopPlay("BananaCry");
                //FindObjectOfType<AudioManager>().StopPlay("Wha");
                FindObjectOfType<AudioManager>().StopPlay("Upd");
                FindObjectOfType<AudioManager>().StopPlay("Upd1");
                FindObjectOfType<AudioManager>().StopPlay("Eat");
            }
                
            loseCanvas.SetActive(true);
            youLose = true;
            //if (needAdv)
            //{
            //    //StartCoroutine(Adv());
            //}
        }
    }
    void Win()
    {
        if (!youLose && !loseCanvas.activeSelf)
        {
            if (audioManagerInstance != null)
            {
                FindObjectOfType<AudioManager>().StopPlay("BananaCry");
                FindObjectOfType<AudioManager>().StopPlay("Wha");
                FindObjectOfType<AudioManager>().StopPlay("Upd");
                FindObjectOfType<AudioManager>().StopPlay("Upd1");
                FindObjectOfType<AudioManager>().StopPlay("Eat");
            }
                
            anim.SetBool("NoCry", true);
            winCanvas.SetActive(true);
            //if (needAdv)
            //{
            //    //StartCoroutine(Adv());
            //}
        }    
    }
    //IEnumerator Adv()
    //{
    //    yield return new WaitForSeconds(1f);
    //    ShowAdv();
    //}
}
