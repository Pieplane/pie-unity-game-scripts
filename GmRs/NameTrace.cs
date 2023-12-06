using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTrace : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string nameTrace;

    private void Start()
    {
        text.text = GetComponent<TextMeshProUGUI>().text;
        text.text = nameTrace;
    }
}
