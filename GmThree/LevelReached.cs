using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelReached : MonoBehaviour
{
    public Button[] levels;
    int level;

    private void Start()
    {
        level = PlayerPrefs.GetInt("LevelReach", 1);
        //level = Progress.Instance.PlayerInfo.Level;
        for (int i = 0; i < levels.Length; i++)
        {
            if (i + 1 > level)
            {
                levels[i].interactable = false;
            }
        }
    }
}
