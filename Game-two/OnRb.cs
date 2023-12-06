using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRb : MonoBehaviour
{
    //public GameObject[] halp;
    public GameObject[] players;
    Rigidbody2D rb;
    bool ess = false;
    private void Start()
    {
        ess = false;
        foreach (var item in players)
        {
            rb = item.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
            //var constraints = rb.constraints;
            //constraints |= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            //rb.constraints = constraints;
        }
    }
    private void Update()
    {
        if ((LinesDrawer.alreadyDraw || Timer.endTime) && !ess)
        {
            UnHalp();
            ess = true;
        }
    }

    private void UnHalp()
    {
        foreach (var item in players)
        {
            rb = item.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            //rb.constraints = RigidbodyConstraints2D.None;
            //Debug.Log("Снятие ограничений");
        }
          

    }
}
