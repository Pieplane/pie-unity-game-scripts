using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRight : MonoBehaviour
{
    public Animator anim;
    public void RightParis()
    {
        anim.SetTrigger("Paris");
    }
    public void BackLondon()
    {
        anim.SetTrigger("London");
    }
    public void RightMoscow()
    {
        anim.SetTrigger("Moscow");
    }
    public void RightDubai()
    {
        anim.SetTrigger("Dubai");
    }
    public void BackParis()
    {
        anim.SetTrigger("Paris");
    }
    public void BackMoscow()
    {
        anim.SetTrigger("Moscow");
    }
}
