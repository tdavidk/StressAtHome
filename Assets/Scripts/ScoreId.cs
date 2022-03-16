using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreId : MonoBehaviour
{
    IEnumerator Start()
    {
        WWW scoreUser = new WWW("https://stressathomegame.000webhostapp.com/api/detail_score_username.php");
        yield return scoreUser;
        Debug.Log("score user " + scoreUser);
    }
}
