using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class video : MonoBehaviour
{
    //判斷靜音要開或是關
    bool isMute;
    //景片物件
    public VideoPlayer VideoObj;
    [Header("控制影片 速度的拉霸")]
    public Slider VideoSlider;
    //計時器
    float Timer;
    [Header("設定一個時間檢測影片是否撥放完畢")]
    public float SetTime;
    //如果點了靜音的按鈕
    public void ClickMute() {
        //如果Boo1 為false傅換成true，如果Bool為true傳換成false
        isMute = !isMute;
        //控制影片物件的靜音開關
        VideoObj.SetDirectAudioMute(0, isMute);
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //當拉霸的數值>=0，代表有再撥放影片
        if (VideoSlider.value > 0)
        {
            //開始做計時 Timer=Timert Time. de l taTime;
            //Time.deltaTime執行完Update每frame需要的秒數，不是固定值
            Timer += Time.deltaTime;
            //如果Timer時間大於檢測時間，並且影片撥放亮畢
            if (Timer > SetTime && !VideoObj.isPlaying)
                //跳到遊戲場景
                Application.LoadLevel("Game");
        }
        //如果使用者把S1ider條回0
        else
        {
            //Timer歸零
            Timer = 0;

        }
    }
}
