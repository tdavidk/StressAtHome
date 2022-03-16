using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverpanel;
    public GameObject scoreTextGame;
    public Text scoreText;

    private string url = "https://stressathomegame.000webhostapp.com/api/update_score.php";
    WWWForm form;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverpanel.SetActive(true);
            scoreTextGame.SetActive(false);
            scoreText.text = "Score : " + ((int)ScoreManager.score);
            StartCoroutine(gameOver());
        }

    }

    IEnumerator gameOver()
    {
        form = new WWWForm();
        form.AddField("username", PlayerPrefs.GetString("username"));
        form.AddField("score_history", ScoreManager.score.ToString());
        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("Update Failed"))
                {
                    Debug.Log("Gagal update score");
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    PlayerPrefs.SetInt("score_history", ((int)ScoreManager.score));
                    Debug.Log("berhasil update score");
                    Debug.Log("<color=green>" + w.text + "</color>");
                }
            }
        }
        w.Dispose();
    }

    public void GoToMainMenu()
    {
        ScoreManager.score = 0;
        CameraMovement.cameraSpeed = 10;
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        ScoreManager.score = 0;
        CameraMovement.cameraSpeed = 10;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
