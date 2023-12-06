using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] GameObject banana;
    [SerializeField] GameObject loseCanvas;
    //[SerializeField] GameObject totalCanvas;
    GameObject[] barrier;
    [SerializeField] CollisionBlack black;
    [SerializeField] CollisionBlack happy;
    [SerializeField] SpawnBarrier bar;
    [SerializeField] private GameObject[] moveCats;
    float catsSpeed;

    float xMin, yMin;

    float bananaPosition;

    public Movement movement;

    public TrailRenderer trail;

    bool onePlay;
    public bool oneGameMusic;
    public bool twoGameMusic;
    public bool threeGameMusic;
    public Button continueButton;

    [DllImport("__Internal")]
    private static extern void ShowReward();

    private void Start()
    {
        if (Buy.choiceBanan)
        {
            catsSpeed = 1300;
        }
        else if (Buy.skate)
        {
            catsSpeed = 1400;
        }
        else if (Buy.samokat)
        {
            catsSpeed = 2000;
        }
        else if (Buy.skuter)
        {
            catsSpeed = 2600;
        }
        else
        {
            catsSpeed = 1300;
        }
        
        onePlay = false;
        //FindObjectOfType<AudioManager>().StopPlay("Game");
        //FindObjectOfType<AudioManager>().Play("Cry");
    }
    private void Update()
    {
        if(banana != null)
        {
            if (this.gameObject.activeSelf && !onePlay)
            {
                Debug.Log("AAA");
                FindObjectOfType<AudioManager>().StopPlay("Game");
                FindObjectOfType<AudioManager>().StopPlay("GameTwo");
                FindObjectOfType<AudioManager>().StopPlay("GameThree");
                FindObjectOfType<AudioManager>().Play("Cry");
                onePlay = true;
            }
            xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            bananaPosition = banana.transform.position.x;
        }
    }
    public void RestartLevel()
    {
        trail.enabled = false;
        movement.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ContinueGame()
    {
        continueButton.interactable = true;
        trail.enabled = false;
        if (Buy.skate || Buy.samokat || Buy.skuter)
        {
            anim.SetBool("Fall", false);
        }
        else
        {
            anim.SetBool("Fall", false);
            anim.SetTrigger("ChoiceBanana");
        }
        
        barrier = GameObject.FindGameObjectsWithTag("Obstacle");
        if(banana != null)
        {
            banana.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            banana.GetComponent<Movement>().enabled = true;
        }
        loseCanvas.SetActive(false);
        if(black != null)
        {
            black.GetAround();
        }
        if(happy != null)
        {
            happy.GetAround();
        }
        
        bar.needSpawn = true;
        foreach (GameObject item in barrier)
        {
            if(trail.enabled == false)
            {
                item.SetActive(false);
            }
        }
        if(moveCats != null)
        {
            foreach (GameObject item in moveCats)
            {
                item.GetComponent<MoveCat>().enabled = true;
                item.GetComponent<MoveCat>().speed = catsSpeed;
                //item.GetComponent<MoveCat>().Start();
            }
            Vector3 temp = moveCats[0].transform.position;
            //temp.x = xMin + 1f;
            temp.x = xMin - 2f;
            temp.y = yMin + 3f;
            moveCats[0].transform.position = temp;

            Vector3 temp1 = moveCats[1].transform.position;
            //temp1.x = xMin + 1f;
            temp1.x = xMin - 2f;
            temp1.y = yMin + 6f;
            moveCats[1].transform.position = temp1;
        }
        
        
        FindObjectOfType<AudioManager>().StopPlay("Cry");
        if (oneGameMusic)
        {
            FindObjectOfType<AudioManager>().Play("Game");
        }
        else if (twoGameMusic)
        {
            FindObjectOfType<AudioManager>().Play("GameTwo");
        }
        else if (threeGameMusic)
        {
            FindObjectOfType<AudioManager>().Play("GameThree");
        }
        
        onePlay = false;
    }

    public void RewardVideo()
    {
        continueButton.interactable = false;
        ShowReward();
    }
}
