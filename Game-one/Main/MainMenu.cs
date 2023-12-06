using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    public Animator transition;
    public float transitionTime = 1f;

    public static bool music = false;

    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject controlsMenu;


    public AudioClip audioClip;



    public AudioMixer audioMixer;
    public AudioMixer soundsMixer;

    public Slider sliderMusic;
    public Slider sliderSounds;


    private void Start()
    {
        ShowAdv();

        sliderMusic.value = PlayerPrefs.GetFloat("save");
        sliderSounds.value = PlayerPrefs.GetFloat("savesounds");


    }
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Options()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        if (!music)
        {
            NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Play();
            music = true;
        }
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void Controls()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        mainMenu.SetActive(false);
        optionMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void BackOption()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void BackControls()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        optionMenu.SetActive(false);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        FindObjectOfType<AudioManager>().Play("Click");
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void SetVolue(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("save", volume);
    }

    public void SetVolueSounds(float volume)
    {
        soundsMixer.SetFloat("volumeSounds", volume);
        PlayerPrefs.SetFloat("savesounds", volume);
    }
}
