using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UpdateLevel : MonoBehaviour
{
    int level;
    public TextMeshProUGUI levelText;

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 1;
        levelText.text = level.ToString();
    }

}
