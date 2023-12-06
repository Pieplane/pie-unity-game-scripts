using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportDefinition : MonoBehaviour
{
    public Animator animator;
    public GameObject[] transport;

    private void Start()
    {
        if (Buy.choiceBanan)
        {
            animator.SetTrigger("ChoiceBanana");
        }
        else if (Buy.skate)
        {
            transport[0].SetActive(true);
        }
        else if (Buy.samokat)
        {
            transport[1].SetActive(true);
        }
        else if (Buy.skuter)
        {
            transport[2].SetActive(true);
        }
        else
        {
            animator.SetTrigger("ChoiceBanana");
        }
    }
}
