using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public float timeForNextLevel = 0f;
    public int levelToUnlock = 0;
    int levelalready;
    // Update is called once per frame
    private void Start()
    {
        levelToUnlock = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if (LinesDrawer.alreadyDraw)
        {
                Invoke("NextLevel", timeForNextLevel);
            
        }
        
    }
    void NextLevel()
    {
        levelalready = PlayerPrefs.GetInt("levelReached");
        if (levelToUnlock > levelalready)
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
