using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorControllerOpenOut : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    public GameObject mainTrigger;

    [SerializeField] private AudioSource soundDoor;

    public AudioClip soundOpen;
    public AudioClip soundClose;

    bool playingAnother = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (playingAnother == false)
            {
                soundDoor.GetComponent<AudioSource>().clip = soundOpen;
                soundDoor.GetComponent<AudioSource>().Play();
                playingAnother = true;
            }
            mainTrigger.SetActive(false);
            myDoor.SetBool("OpeningOut", true);
        }
        else if(other.tag == "Enemy")
        {
            if (playingAnother == false)
            {
                soundDoor.GetComponent<AudioSource>().clip = soundOpen;
                soundDoor.GetComponent<AudioSource>().Play();
                playingAnother = true;
            }
            mainTrigger.SetActive(false);
            myDoor.SetBool("OpeningOut", true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
            StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(5);
        myDoor.SetBool("OpeningOut", false);
        mainTrigger.SetActive(true);
        
        if(playingAnother == true)
        {
            soundDoor.GetComponent<AudioSource>().clip = soundClose;
            soundDoor.GetComponent<AudioSource>().Play();
            playingAnother = false;
        }

    }

}
