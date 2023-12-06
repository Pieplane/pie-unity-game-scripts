using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool Kursor = false;

    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;
    public GameObject optionsMenuUI;


    public AudioMixer audioMixer;
    public AudioMixer soundsMixer;

    public AudioClip musicMenu;

    public Slider sliderMusic;
    public Slider sliderSounds;


    private void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("save");
        sliderSounds.value = PlayerPrefs.GetFloat("savesounds");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameMaster.MusicLoad = true;
    }
    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameMaster.MusicLoad = false;


    }
    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        MainMenu.music = false;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().clip = musicMenu;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


    public void BackControls()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        controlsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void BackOptionsButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }


    public void ControlsPause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
    }

    public void OptionsPause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
        Debug.Log("Quit Game");
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
