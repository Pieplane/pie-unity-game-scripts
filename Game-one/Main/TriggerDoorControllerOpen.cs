using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TriggerDoorControllerOpen : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    public GameObject anotherTrigger;

    [SerializeField] private AudioSource soundOpen = null;
    public AudioClip openSound;
    public AudioClip closeSound;
    bool playing = false;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
                if (playing == false)
                {
                    soundOpen.GetComponent<AudioSource>().clip = openSound;
                    soundOpen.GetComponent<AudioSource>().Play();
                    playing = true;
                }
                anotherTrigger.SetActive(false);
                myDoor.SetBool("Opening", true);
                Debug.Log("Open");
        }
        else if(other.tag == "Enemy")
        {
            if (playing == false)
            {
                soundOpen.GetComponent<AudioSource>().clip = openSound;
                soundOpen.GetComponent<AudioSource>().Play();
                playing = true;
            }
            anotherTrigger.SetActive(false);
            myDoor.SetBool("Opening", true);
            Debug.Log("Open");
        }

        

    }
 
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(5f);
        myDoor.SetBool("Opening", false);
        anotherTrigger.SetActive(true);
        if(playing == true)
        {
            playing = false;
            soundOpen.GetComponent<AudioSource>().clip = closeSound;
            soundOpen.GetComponent<AudioSource>().Play();
        }
        
    }

}
