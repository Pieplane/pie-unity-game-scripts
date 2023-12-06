using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdatPlace : MonoBehaviour
{
    public TextMeshProUGUI places;
    public Finish fin;

    private void Start()
    {
        places.text = fin.bananaPlace;
    }
}
