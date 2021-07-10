using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject howToPlay;
    public GameObject settings;
    public GameObject iconSettings;
    bool boolhowToPlay = false;
    bool boolSettings = false;
    [Space]
    public AudioSource audioSource;

    public void playClip()
    {
        audioSource.Play();
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Logout()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Login");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        if(boolhowToPlay == false)
        {
            howToPlay.SetActive(true);
            boolhowToPlay = true;
        }
        else
        {
            howToPlay.SetActive(false);
            boolhowToPlay = false;
        }
    }

    public void Settings()
    {
        if (boolSettings == false)
        {
            settings.SetActive(true);
            iconSettings.SetActive(false);
            boolSettings = true;
        }
        else
        {
            settings.SetActive(false);
            iconSettings.SetActive(true);
            boolSettings = false;
        }
    }
}
