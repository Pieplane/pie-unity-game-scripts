using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 5f;


    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
            NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Pause();
            FindObjectOfType<AudioManager>().Play("GameOver");

            Invoke("Restart", restartDelay);
        }
        
    }
    void Restart()
    {
        Players.died = false;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameMaster.MusicLoad = true;
        FindKey.keyPicked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

}
