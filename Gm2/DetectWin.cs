using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DetectWin : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public Animator anim;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    //public bool needAdv = false;
    AudioManager audioManagerInstance;

    private void Start()
    {
        audioManagerInstance = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !loseCanvas.activeSelf)
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
    }
    //IEnumerator Adv()
    //{
    //    yield return new WaitForSeconds(1f);
    //    ShowAdv();
    //}
}
