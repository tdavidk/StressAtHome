using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoginServer : MonoBehaviour
{
    [SerializeField] Text user;
    [Space]
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Text errorMessages;
    [SerializeField] GameObject progressCircle;
    [SerializeField] Button loginButton;

    private string url = "http://localhost:8888/kuliah/Pengembangan%20Game%20Online/StudyAtHome/login.php";
    WWWForm form;
    public void OnLoginButtonClicked()
    {
        loginButton.interactable = false;
        progressCircle.SetActive(true);
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        form = new WWWForm();
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
                if (w.text.Contains("error"))
                {
                    errorMessages.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcom panel
                    //welcomePanel.SetActive(true);
                    user.text = username.text;
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                }
            }
        }
        loginButton.interactable = true;
        progressCircle.SetActive(false);
        w.Dispose();
    }
}

