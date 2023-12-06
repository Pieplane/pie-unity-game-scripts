using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject key01;
    public GameObject key02;
    public GameObject key03;
    public GameObject key04;
    public GameObject key05;

    public void Start()
    {
        int spawn = UnityEngine.Random.Range(0, 5);
        if(spawn == 0)
        {
            key01.SetActive(true);
            key02.SetActive(false);
            key03.SetActive(false);
            key04.SetActive(false);
            key05.SetActive(false);
        }
        else if(spawn == 1)
        {
            key01.SetActive(false);
            key02.SetActive(true);
            key03.SetActive(false);
            key04.SetActive(false);
            key05.SetActive(false);
        }
        else if(spawn == 2)
        {
            key01.SetActive(false);
            key02.SetActive(false);
            key03.SetActive(true);
            key04.SetActive(false);
            key05.SetActive(false);
        }
        else if(spawn == 3)
        {
            key01.SetActive(false);
            key02.SetActive(false);
            key03.SetActive(false);
            key04.SetActive(true);
            key05.SetActive(false);
        }
        else
        {
            key01.SetActive(false);
            key02.SetActive(false);
            key03.SetActive(false);
            key04.SetActive(false);
            key05.SetActive(true);
        }
    }
}
