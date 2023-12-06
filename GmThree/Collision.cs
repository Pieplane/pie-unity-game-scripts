using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private SpawnBarrier spawn;
    [SerializeField] private Animator anim;
    [SerializeField] private Barrier barrier;
    [SerializeField] private Movement moveBanana;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject totalCanvas;
    [SerializeField] private GameObject[] moveCats;
    [SerializeField] private GameObject bananaCat;
    //float yMin;
    float banana;
    //bool doIt;

    //private void Start()
    //{
    //    doIt = false;
    //}
    private void Update()
    {
        //yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        banana = bananaCat.transform.position.x;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Finish")
        {
            FindObjectOfType<AudioManager>().Play("Kick");
            Debug.Log("Столкновение");
            spawn.needSpawn = false;
            anim.SetBool("Fall", true);
            //barrier.speed = 0f;
            //barrier.enabled = false;
            moveBanana.enabled = false;
            if (!totalCanvas.activeSelf)
            {
                loseCanvas.SetActive(true);
            }
            moveBanana.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("StopMove", .1f);
            //StopMove();
        }
    }
    void StopMove()
    {
        //loseCanvas.SetActive(true);
        foreach (GameObject item in moveCats)
        {
            item.GetComponent<MoveCat>().enabled = false;
   
            //    if(item.transform.position.x > banana)
            //    {
            //    item.GetComponent<MoveCat>().enabled = false;
            //    //Vector3 temp = transform.position;
            //    //temp.y = yMin;
            //    //item.transform.position = temp;
            //    }   
        }
        //while(moveCats[0].transform.position.x > banana && moveCats[1].transform.position.x > banana)
        //{
        //    doIt = true; 
        //}
    }
}
