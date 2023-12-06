using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenu : MonoBehaviour
{
    public Animator anim;

    public void PlayAnim()
    {
        anim.SetTrigger("Play");
        FindObjectOfType<AudioManager>().Play("Bub");
    }

}
