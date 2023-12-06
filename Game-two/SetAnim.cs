using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetAnim : MonoBehaviour
{
    Animator anim;
    public GameObject dog;
    public GameObject cat;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame

    void HappyCat()
    {
        anim.SetBool("NoCry", true);
        dog.SetActive(true);
        cat.SetActive(true);
        Invoke("NextLevel", 2f);
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
