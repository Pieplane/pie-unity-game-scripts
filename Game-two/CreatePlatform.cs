using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatePlatform : MonoBehaviour
{
    public GameObject checkPlatform;
    public float timeActivePlatform = 0f;

    private void OnEnable()
    {
        LinesDrawer.sub += Platform;
    }
    private void OnDisable()
    {
        LinesDrawer.sub -= Platform;
    }

    private void Platform()
    {
        Debug.Log("Create Check");
        Invoke("ActivePlatform", timeActivePlatform);
    }
    void ActivePlatform()
    {
        checkPlatform.SetActive(true);
    }
    
}
