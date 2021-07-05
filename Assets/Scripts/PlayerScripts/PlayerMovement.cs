using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpPower;

    private Rigidbody2D body;

    private Animator anim;

    public Score scoreText;

    public Score alloverScoreText;

    public GameObject YouDied;

    public GameObject PauseMenu;

    public GameObject Score;

    public AudioSource wing;

    public AudioSource swoosh;

    public AudioSource hit;

    public AudioSource die;

    public AudioSource point;

    public AudioSource BackgroundMusic;

    public GameObject unMuted;

    public GameObject muted;

    private bool Muted = false;

    private bool dead = false;

    private bool Start = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && dead == false)
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jumped");
            wing.Play();
            swoosh.Play();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            BackgroundMusic.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            scoreText.ScoreUp();
            alloverScoreText.ScoreUp();
            point.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground")  || collision.gameObject.CompareTag("Pipe"))
        {
            //game over
            Time.timeScale = 0f;
            YouDied.SetActive(true);
            Score.SetActive(false);
            hit.Play();  
            die.Play();
            dead = true;
            unMuted.SetActive(false);
            muted.SetActive(true);
            BackgroundMusic.Pause();
        }
    }

    public void ReplayBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        unMuted.SetActive(true);
        muted.SetActive(false);
        BackgroundMusic.UnPause();
    }

    public void MenuButton()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }

    public void Idle()
    {
        anim.SetTrigger("NotJumped");
    }

    public void Mute()
    {
        unMuted.SetActive(false);
        muted.SetActive(true);
        BackgroundMusic.Pause();
    }

    public void UnMute()
    {
        unMuted.SetActive(true);
        muted.SetActive(false);
        BackgroundMusic.UnPause();
    }
}
