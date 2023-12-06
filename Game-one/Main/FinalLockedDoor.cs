using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FinalLockedDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private AudioSource soundOpen = null;
    public AudioClip lockedSound;
    public AudioClip openSound;
    bool opening = false;

    public GameObject findKey;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (opening == false && !FindKey.keyPicked)
            {
                findKey.SetActive(true);
                soundOpen.GetComponent<AudioSource>().clip = lockedSound;
                soundOpen.GetComponent<AudioSource>().Play();
                opening = true;
                Debug.Log("Open");

            }
            else if (opening == false && FindKey.keyPicked)
            {
                soundOpen.GetComponent<AudioSource>().clip = openSound;
                soundOpen.GetComponent<AudioSource>().Play();
                myDoor.SetBool("Opening", true);
                Debug.Log("hmm");
            }
            
        }
        else if (other.tag == "Enemy")
        {
            if (opening == false)
            {
                opening = true;
            }
            Debug.Log("Open");
        }



    }

    private void OnTriggerExit(Collider other)
    {
        findKey.SetActive(false);
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(5f);
        if (opening == true)
        {
            opening = false;
        }

    }

}
