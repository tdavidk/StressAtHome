using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float score;
    public GameObject backgroundLv1;
    public GameObject backgroundLv2;

    public GameObject spawnPowerUp2;
    public GameObject spawnObstacle2;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if(score> 60)
            {
                CameraMovement.cameraSpeed = 17;
                spawnPowerUp2.SetActive(true);
                spawnObstacle2.SetActive(true);
                backgroundLv1.SetActive(false);
                backgroundLv2.SetActive(true);
            }
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
    }



}
