using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Happy : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public MoveCat move;
    public float timeForWinCanvas = 0f;
    public float timeForLoseCanvas = 0f;

    public GameObject winCanvas;
    public GameObject loseCanvas;
    public Animator anim;

    //public bool needAdv = false;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !loseCanvas.activeSelf)
        {
            Debug.Log("Happy");
            if(move != null)
            {
                move.speed = 0f;
            }
            
            Invoke("WinCanvas", timeForWinCanvas);
        }
        else if (collision.tag == "Enemy" && !winCanvas.activeSelf)
        {
            Debug.Log("Enemy catch you");
            if(move != null)
            {
                move.speed = 0f;
            }
            Invoke("LoseCanvas", timeForLoseCanvas);
        }
    }
    private void WinCanvas()
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
        //    StartCoroutine(Adv());
        //}
    }
    private void LoseCanvas()
    {
        if (audioManagerInstance != null)
        {
            FindObjectOfType<AudioManager>().StopPlay("BananaCry");
            //FindObjectOfType<AudioManager>().StopPlay("Wha");
            FindObjectOfType<AudioManager>().StopPlay("Upd");
            FindObjectOfType<AudioManager>().StopPlay("Upd1");
            FindObjectOfType<AudioManager>().StopPlay("Eat");
        }
            
            loseCanvas.SetActive(true);
        //if (needAdv)
        //{
        //    StartCoroutine(Adv());
        //}
    }
    //IEnumerator Adv()
    //{
    //    yield return new WaitForSeconds(1f);
    //    ShowAdv();
    //}
}
