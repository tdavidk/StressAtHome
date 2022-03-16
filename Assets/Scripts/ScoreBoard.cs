using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text rank1;
    public Text rank2;
    public Text rank3;
    public Text rank4;
    public Text rank5;
    public Text poin1;
    public Text poin2;
    public Text poin3;
    public Text poin4;
    public Text poin5;

    public string[] items;

    IEnumerator Start()
    {
        WWW itemsData = new WWW("https://stressathomegame.000webhostapp.com/api/leader_board.php");
        yield return itemsData;
        items = itemsData.text.Split(';');
        rank1.text = "1. " + GetDataValue(items[0], "Nama:");
        rank2.text = "2. " + GetDataValue(items[1], "Nama:");
        rank3.text = "3. " + GetDataValue(items[2], "Nama:");
        rank4.text = "4. " + GetDataValue(items[3], "Nama:");
        rank5.text = "5. " + GetDataValue(items[4], "Nama:");
        poin1.text = GetDataValue(items[0], "Score:");
        poin2.text = GetDataValue(items[1], "Score:");
        poin3.text = GetDataValue(items[2], "Score:");
        poin4.text = GetDataValue(items[3], "Score:");
        poin5.text = GetDataValue(items[4], "Score:");
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) , index.Length);
        if (value.Contains("&")) value = value.Remove(value.IndexOf("&"));
        return value;
    }


}
