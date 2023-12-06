using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindKey : MonoBehaviour
{
    public static bool keyPicked = false;


    void Update()
    {
        if (GameObject.FindWithTag("Key") == null)
        {
            
            keyPicked = true;
            Debug.Log("Key was picked");
        }
        
    }
}
