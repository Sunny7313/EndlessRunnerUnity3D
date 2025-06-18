using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Score;
    public GameObject pauseMenuUI;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            Score.text = "Score: " + PlayerPrefs.GetInt("score");
        }
        if (SceneManager.GetActiveScene().name == "Level")
        {
            pauseMenuUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void home()
    {
        SceneManager.LoadScene("Menu");
    }
    public void right()
    {
        if (transform.position.x == 0 || transform.position.x == -1.25f)
        {
            transform.Translate(1.25f, 0, 0);
        }
    }
    public void Left()
    {
        if (transform.position.x == 0 || transform.position.x == 1.25f)
        {
            transform.Translate(-1.25f, 0, 0);
        }
    }
    public void up()
    {
        Animator anim = GetComponent<Animator>();
        Rigidbody rb = GetComponent<Rigidbody>();
        anim.SetTrigger("jump");
        if(rb.velocity.y == 0)
        {
            rb.velocity = new Vector3(0, 4f, 0);
        }
    }
    public void down()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("roll");
    }
    public void pause(GameObject pauseObj)
    {
        Time.timeScale = 0f;
        pauseObj.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void resume(GameObject pauseObj)
    {
        Time.timeScale = 1f;
        pauseObj.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
}
