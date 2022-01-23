using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("敵機物件")]
    public GameObject[] Enemy;
    [Header("敵機生成時間")]
    public float SetTime;
    [Header("X最小值")]
    public float XMin;
    [Header("X最大值")]
    public float XMax;
    [Header("PauseUI")]
    public GameObject PauseUI;

    //AddScore
    [Header("AddScore")]
    public float AddScore;
    //Score
    float TotalScore;
    public Text ScoreText;
    //save TotalScore
    string totalScore = "TotalScore";
    //save HeightScore
    string HeightScore = "HeightScore";

    // Start is called before the first frame update
    void CreateEnemy()
    {
        //動態生成敵機
        //Random.Rangen隨機直(最小值,最大值)
        Instantiate(Enemy[Random.Range(0, Enemy.Length)], new Vector3(Random.Range(XMin, XMax), transform.position.y, transform.position.z), transform.rotation);
    }
    void Start()
    {
        InvokeRepeating("CreateEnemy", SetTime, SetTime);
        Staticvar.isStop = false;
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause()
    {
        PauseUI.SetActive(true);
        Staticvar.isStop = true;
        Time.timeScale = 0f;

    }
    public void Unpause()
    {
        PauseUI.SetActive(false);
        Staticvar.isStop = false;
        Time.timeScale = 1f;

    }
    public void Score()
    {
        TotalScore += AddScore;
        ScoreText.text = "Score" + TotalScore;
    }
    public void SaveScoreData()
    {
        PlayerPrefs.SetFloat(totalScore, TotalScore);
        Debug.Log(PlayerPrefs.HasKey(HeightScore));
        //檢查是否HeightScore有存放數值
        if (PlayerPrefs.HasKey(HeightScore))
        {

            if (PlayerPrefs.GetFloat(HeightScore) > TotalScore)
            {
                //如果目前分數<最高分數，最高分數值不更改

            }
            else
            {
                //如果目前分數>最高分數，最高分數資料更新
                PlayerPrefs.SetFloat(HeightScore, TotalScore);
            }
        }
        else
        {
            //第一筆遊戲分數直接為最高分數
            PlayerPrefs.SetFloat(HeightScore, TotalScore);
        }
    }
}
