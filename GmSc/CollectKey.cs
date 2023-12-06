using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public MoveCat move;
    public float timeForWinCanvas = 0f;
    public float timeForLoseCanvas = 0f;
    AudioManager audioManagerInstance;
    public Animator anim;
    public Animator frence;
    public bool frence1;
    public bool frence2;
    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !loseCanvas.activeSelf)
        {
            Debug.Log("Happy");
            move.speed = 0f;
            Invoke("WinCanvas", timeForWinCanvas);
            this.gameObject.SetActive(false);
        }
        else if (collision.tag == "Enemy" && !winCanvas.activeSelf)
        {
            Debug.Log("Enemy catch you");
            move.speed = 0f;
            Invoke("LoseCanvas", timeForLoseCanvas);
            this.gameObject.SetActive(false);
        }
    }
    private void WinCanvas()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
            FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Eat");
        }
        if(frence != null)
        {
            if (frence1)
            {
                frence.SetTrigger("Open");
            }
            else if (frence2)
            {
                frence.SetTrigger("Open2");
            }
            
        }
        anim.SetBool("NoCry", true);
        winCanvas.SetActive(true);
        //if (needAdv)
        //{
        //    StartCoroutine(Adv());
        //}
    }
    private void LoseCanvas()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
            FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Eat");
        }

        loseCanvas.SetActive(true);
        //if (needAdv)
        //{
        //    StartCoroutine(Adv());
        //}
    }
}
