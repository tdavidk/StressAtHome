using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Text player;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Name : " + PlayerPrefs.GetString("username"));
        Debug.Log("score : " + PlayerPrefs.GetInt("score_history"));
        player.text = "username : " + PlayerPrefs.GetString("username").ToString();
        highScore.text = "High Score : " + PlayerPrefs.GetInt("score_history");
        //Debug.Log(PlayerPrefs.GetInt("score_history"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
