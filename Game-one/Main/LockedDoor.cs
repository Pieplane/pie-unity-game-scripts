using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LockedDoor : MonoBehaviour
{
    public GameObject anotherTrigger;

    [SerializeField] private AudioSource soundOpen = null;
    public AudioClip openSound;
    bool playing = false;

    public GameObject lockedMessenge;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            lockedMessenge.SetActive(true);
            if (playing == false)
            {
                soundOpen.GetComponent<AudioSource>().clip = openSound;
                soundOpen.GetComponent<AudioSource>().Play();
                playing = true;
            }
            anotherTrigger.SetActive(false);
            Debug.Log("Open");
        }
        else if (other.tag == "Enemy")
        {
            if (playing == false)
            {
                playing = true;
            }
            anotherTrigger.SetActive(false);
            Debug.Log("Open");
        }



    }

    private void OnTriggerExit(Collider other)
    {
        lockedMessenge.SetActive(false);
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(5f);
        anotherTrigger.SetActive(true);
        if (playing == true)
        {
            playing = false;
        }

    }

}
