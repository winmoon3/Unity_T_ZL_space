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
    void Start()
    {
        InvokeRepeating("CreateEnemy", SetTime, SetTime);

    }
    void CreateEnemy()
    {
        //動態生成敵機
        //Random.Rangen隨機直(最小值,最大值)
        Instantiate(Enemy[Random.Range(0, Enemy.Length)], new Vector3(Random.Range(XMin, XMax), transform.position.y, transform.position.z), transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score()
    {
        TotalScore += AddScore;
        ScoreText.text = "Score" + TotalScore;
    }
    public void SaveScoreData()
    {
        PlayerPrefs.SetFloat(totalScore, TotalScore);
    }
}
