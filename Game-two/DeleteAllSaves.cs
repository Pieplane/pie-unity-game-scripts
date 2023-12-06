using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAllSaves : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
