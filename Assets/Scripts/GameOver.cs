using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverpanel;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverpanel.SetActive(true);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
