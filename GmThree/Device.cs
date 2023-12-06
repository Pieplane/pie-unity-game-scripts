using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            this.gameObject.SetActive(false);
        }
        else
            return;
    }
}
