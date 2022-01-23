using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    [Header("目前分數的文字")]
    public Text ScoreText;
    [Header("目前最高分數的文字")]
    public Text HeightScoreText;
    //儲存目前得分的欄位名稱
    string totalScore = "TotalScore";
    //儲存最高分數欄位名稱
    string HeightScore = "HeightScore";
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "目前得分：" + PlayerPrefs.GetFloat(totalScore);
        HeightScoreText.text = "最高得分：" + PlayerPrefs.GetFloat(HeightScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
