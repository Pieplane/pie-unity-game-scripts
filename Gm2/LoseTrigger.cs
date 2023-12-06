using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public GameObject loseCanvas;
    public static bool loser = false;

    private void Start()
    {
        loser = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            loseCanvas.SetActive(true);
            loser = true;
        }
    }
}
