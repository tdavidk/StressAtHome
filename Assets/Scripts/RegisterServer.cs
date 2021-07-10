using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterServer : MonoBehaviour
{
    static string user;
    [Space]
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Text errorMessages;
    [SerializeField] GameObject progressCircle;
    [SerializeField] Button registerButton;

    public GameObject errorMassagePanel;
    private string url = "https://stressathome.000webhostapp.com/api/register.php";
    private string scoreId = "https://stressathome.000webhostapp.com/api/detail_score_username.php";
    WWWForm form;
    WWWForm formUsername;

    public void OnRegisterButtonClicked()
    {
        registerButton.interactable = false;
        progressCircle.SetActive(true);
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        form = new WWWForm();
        formUsername = new WWWForm();
        formUsername.AddField("username", username.text);
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        WWW w = new WWW(url, form);
        yield return w;
        Debug.Log("ISI DARI W TEXT " + w.text);
        if (w.error != null)
        {
            errorMessages.text = "404 not found!";
            errorMassagePanel.SetActive(true);
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if(w.text.Contains("email null"))
                {
                    errorMessages.text = "Please Fill username Field";
                    errorMassagePanel.SetActive(true);
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else if(string.IsNullOrEmpty(password.text))
                {
                    errorMessages.text = "Please Fill Password Field";
                    errorMassagePanel.SetActive(true);
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else if (w.text.Contains("Username Already Used"))
                {
                    errorMessages.text = "Username Already Used";
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
                    user = username.text;
                    errorMessages.text = "";
                    PlayerPrefs.SetString("username", username.text);
                    PlayerPrefs.SetInt("score_history", int.Parse(wScoreId.text));
                    Debug.Log("<color=green>" + w.text + "</color>");
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }

        registerButton.interactable = true;
        progressCircle.SetActive(false);
        w.Dispose();
    }
}

