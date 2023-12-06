using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCat : MonoBehaviour
{
    public GameObject cat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(cat != null)
            {
                cat.GetComponent<Animator>().enabled = false;
                cat.GetComponent<MoveCat>().enabled = false;
            }
        }
    }
}
