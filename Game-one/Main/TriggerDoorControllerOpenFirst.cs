using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TriggerDoorControllerOpenFirst : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    public GameObject anotherTrigger;

    [SerializeField] private AudioSource soundOpen = null;
    public AudioClip openSound;
    public AudioClip closeSound;
    bool playing = false;

    public GameObject openMessengeUI;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            openMessengeUI.SetActive(true);
            if (Input.GetKey(KeyCode.E))
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
        openMessengeUI.SetActive(false);
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
