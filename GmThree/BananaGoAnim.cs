using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaGoAnim : MonoBehaviour
{
    public Pied pied;
    Animator anim;

    private void Start()
    {
        anim = pied.banana.GetComponent<Animator>();
        
    }
}
