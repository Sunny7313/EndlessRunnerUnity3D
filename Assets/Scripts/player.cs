using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Animator anim;
    float jump = 4f;
    int score = 0;
    float distance = 0f;
    float delay = 0.96f;
    private float distanceTraveled;
    private float startZPosition;
    private bool isTrackingDistance = false;
    public Text scoreText;
    public Text highScoreText;
    public Text distanceText;
    public AudioClip coinClip;
    AudioSource collectableAudio;
    public Image[] life;
    int health = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        scoreText.text = "Score: " + score; 
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        distanceText.text = "Distance: " + distance;
        StartCoroutine(StartDistanceTrackingAfterDelay());
    }

    private IEnumerator StartDistanceTrackingAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        startZPosition = transform.position.z;
        isTrackingDistance = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x == 0)
        {
            transform.Translate(-1.25f, 0, 0);
        }   
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x == 0)
        {
            transform.Translate(1.25f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x == 1.25)
        {
            transform.position = new Vector3(transform.position.x - 1.25f, 0.25f, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x == -1.25)
        {
            transform.position = new Vector3(transform.position.x + 1.25f, 0.25f, 0);
        }
        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))&& rb.velocity.y == 0)
        {
            anim.SetTrigger("jump");
            rb.velocity = new Vector3(0, jump, 0);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("roll");
        }
        if(score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "High Score: " + score;
        }
        if (isTrackingDistance)
        {
            distance += Time.deltaTime * 5f;
            distanceText.text = Mathf.FloorToInt(distance).ToString() + " m";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            score++;
            scoreText.text = "Score: " + score;
            collectableAudio = GetComponent<AudioSource>();
            collectableAudio.clip = coinClip;
            collectableAudio.Play();
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("vehicle"))
        {
            health--;
            life[health].enabled = false;
            Destroy(other.gameObject);
            if (health == 0)
            {
                PlayerPrefs.SetInt("score", score);
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
