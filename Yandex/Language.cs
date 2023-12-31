using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    public string CurrentLanguage;

    public static Language Instance;

    //private IEnumerator Start()
    //{
    //    yield return StartCoroutine(WaitForGetLangInitialization());
    //    Debug.Log($"������� ����� ��� �����: {CurrentLanguage}");
    //}

    //private IEnumerator WaitForGetLangInitialization()
    //{
    //    while (string.IsNullOrEmpty(GetLang()))
    //    {
    //        yield return null; // ��������� ���� ����
    //    }

    //    CurrentLanguage = GetLang();
    //}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CurrentLanguage = GetLang();
            //Debug.Log($"������� ����� ��� ����� +{CurrentLanguage}");
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
