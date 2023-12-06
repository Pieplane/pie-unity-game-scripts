using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnim : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    public void LightAnimTrigg()
    {
        anim.SetTrigger("Light");
    }
}
