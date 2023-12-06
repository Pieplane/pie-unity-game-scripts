using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRight : MonoBehaviour
{
    public Animator anim;

    public void AnimButtown()
    {
        anim.SetTrigger("Right");
    }
}
