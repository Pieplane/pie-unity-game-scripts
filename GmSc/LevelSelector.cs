using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    //public int level;
    public TextMeshProUGUI levelText;
    public Button[] levelButtons;
    //AudioManager audioManagerInstance;

    public void Start()
    {
        //audioManagerInstance = FindObjectOfType<AudioManager>();
        //levelText.text = level.ToString();
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
                
        }
    }

    //public void OpenScene()
    //{
    //    if (audioManagerInstance != null)
    //    {
    //        FindObjectOfType<AudioManager>().Play("Bub");
    //    }
    //    SceneManager.LoadScene("Level " + level.ToString());
    //}
}
