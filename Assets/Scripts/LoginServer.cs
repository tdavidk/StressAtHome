using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginServer : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Text errorMessages;
    [Space]
    [SerializeField] GameObject progressCircle;
    [SerializeField] Button loginButton;

    public GameObject errorMassagePanel;
    private string url = "https://stressathomegame.000webhostapp.com/api/login.php";
    private string scoreId = "https://stressathomegame.000webhostapp.com/api/detail_score_username.php";
    WWWForm form;
    WWWForm formUsername;

    private void Start()
    {
        errorMessages.text = "";
    }
    public void OnLoginButtonClicked()
    {
        loginButton.interactable = false;
        progressCircle.SetActive(true);
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        form = new WWWForm();
        formUsername = new WWWForm();
        formUsername.AddField("username", username.text);
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        WWW w = new WWW(url, form);
        yield return w;
        if (w.error != null)
        {
            errorMessages.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("Login Failed"))
                {
                    errorMessages.text = "invalid username or password!";
                    errorMassagePanel.SetActive(true);
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    WWW wScoreId = new WWW(scoreId, formUsername);
                    yield return wScoreId;
                    if (wScoreId.error != null)
                    {
                        errorMassagePanel.SetActive(true);
                        Debug.Log("<color=red>" + wScoreId.text + "</color>");//error
                    }
                    else
                    {
                        Debug.Log("WSCOREID " + wScoreId.ToString());
                        Debug.Log("<color=green>" + wScoreId.text + "</color>");//user exist
                    }
                    //open welcom panel
                    //welcomePanel.SetActive(true);
                    errorMessages.text = "";
                    PlayerPrefs.SetString("username", username.text);
                    PlayerPrefs.SetInt("score_history", int.Parse(wScoreId.text));
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
        loginButton.interactable = true;
        progressCircle.SetActive(false);
        w.Dispose();
    }
}

