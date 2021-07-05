using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credit;

    public GameObject mainMenu;

    public void Play()
    {
        SceneManager.LoadSceneAsync("MainGame");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credit()
    {
        credit.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        credit.SetActive(false);
        mainMenu.SetActive(true);
    }
}
