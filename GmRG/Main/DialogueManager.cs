using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;

    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;

    public Dialogue dialogue;
    public Button continueButton;
    public GameObject skipImage;
    public GameObject continueImage;

    public AudioClip musicGame;


    void Awake()
    {
        sentences = new Queue<string>();
        StartDialogue(dialogue);
        skipImage.SetActive(false);
    }
    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void Update()
    {
        if(sentences.Count == 0)
        {
            continueButton.interactable = false;
            continueImage.GetComponent<Image>().enabled = false;
            skipImage.SetActive(true);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            
            return;
        }

        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.08f);
        }
    }

    public void SkipDialogue()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        PlayerPrefs.SetFloat("time", 0);

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().clip = musicGame;
        NewGameMaster.Instance.gameObject.GetComponent<AudioSource>().Play();
    }

}
