using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject total;
    public GameObject player;
    public GameObject cat1;
    public GameObject cat2;
    public GameObject rocket;
    public GameObject loadSlider;
    public GameObject[] buttown;
    public Movement movement;
    public TrailRenderer trail;
    public string bananaPlace;


    public string[] vs = new string[3];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Black" || collision.tag == "Happy")
        {
            if(player.transform.position.x > cat1.transform.position.x && player.transform.position.x > cat2.transform.position.x)
            {
                bananaPlace = "1";
                if (cat1.transform.position.x > cat2.transform.position.x)
                {
                    vs[0] = player.tag;
                    vs[1] = cat1.tag;
                    vs[2] = cat2.tag;
                }
                else
                {
                    vs[0] = player.tag;
                    vs[1] = cat2.tag;
                    vs[2] = cat1.tag;
                }
            }
            else if(cat1.transform.position.x > player.transform.position.x && cat1.transform.position.x > cat2.transform.position.x)
            {
                if(player.transform.position.x > cat2.transform.position.x)
                {
                    bananaPlace = "2";
                    vs[0] = cat1.tag;
                    vs[1] = player.tag;
                    vs[2] = cat2.tag;
                }
                else
                {
                    bananaPlace = "3";
                    vs[0] = cat1.tag;
                    vs[1] = cat2.tag;
                    vs[2] = player.tag;
                }
            }
            else
            {
                if(cat1.transform.position.x > player.transform.position.x)
                {
                    bananaPlace = "3";
                    vs[0] = cat2.tag;
                    vs[1] = cat1.tag;
                    vs[2] = player.tag;
                }
                else
                {
                    bananaPlace = "2";
                    vs[0] = cat2.tag;
                    vs[1] = player.tag;
                    vs[2] = cat1.tag;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            movement.enabled = false;
            trail.enabled = false;
            if(trail.enabled == false)
            {
                //player.SetActive(false);
                //player.GetComponent<Movement>().moveSpeed = 0f;
                Destroy(player);
            }
            //Destroy(cat1);
            //Destroy(cat2);
            cat1.SetActive(false);
            cat2.SetActive(false);
            rocket.SetActive(false);
            loadSlider.SetActive(false);
            total.SetActive(true);
            foreach (GameObject item in buttown)
            {
                item.SetActive(false);
            }
        }
        
    }
}
