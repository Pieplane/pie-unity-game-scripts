using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Select01()
    {
        SceneManager.LoadScene("Trace01");
    }
    public void Select02()
    {
        SceneManager.LoadScene("Trace02");
    }
    public void Select03()
    {
        SceneManager.LoadScene("Trace03");
    }
    public void Select04()
    {
        SceneManager.LoadScene("Trace04");
    }
    public void Select11()
    {
        SceneManager.LoadScene("Trace11");
    }
    public void Select12()
    {
        SceneManager.LoadScene("Trace12");
    }
    public void Select13()
    {
        SceneManager.LoadScene("Trace13");
    }
    public void Select14()
    {
        SceneManager.LoadScene("Trace14");
    }
    public void Select21()
    {
        SceneManager.LoadScene("Trace21");
    }
    public void Select22()
    {
        SceneManager.LoadScene("Trace22");
    }
    public void Select23()
    {
        SceneManager.LoadScene("Trace23");
    }
    public void Select24()
    {
        SceneManager.LoadScene("Trace24");
    }
    public void Select31()
    {
        SceneManager.LoadScene("Trace31");
    }
    public void Select32()
    {
        SceneManager.LoadScene("Trace32");
    }
    public void Select33()
    {
        SceneManager.LoadScene("Trace33");
    }
    public void Select34()
    {
        SceneManager.LoadScene("Trace34");
    }
    public void BackLevels()
    {
        SceneManager.LoadScene("1");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void ChoiceShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void SettingsOpen()
    {
        SceneManager.LoadScene("Settings");
    }
}
