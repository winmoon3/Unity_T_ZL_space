using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Text ScoreText;
    //save TotalScore
    string totalScore = "TotalScore";
    //save HeightScore
    string HeightScore = "HeightScore";
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "目前得分：" + PlayerPrefs.GetFloat(totalScore);
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
