using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//由於讀取StreamingAssets是讀取外部資料夾，因次要引用System.IO才能讀取到外部資料夾
using System.IO;
//使用Unity UI程式庫
using UnityEngine.UI;
public class LoadStreamingAssetsTexture : MonoBehaviour
{
    [Header("放入聲音的按鈕")]
    public Image SoundButton;
    [Header("控制聲音開關")]
    public bool ControlSound;
    public string FolderPath;
    public string[] filePaths;
    // Start is called before the first frame update
    void Start()
    {
        //抓取streamingAsset資料夾路徑
        FolderPath = Application.streamingAssetsPath;
        //抓取streamingAsset資料夾內所有png圖檔的路徑
        filePaths = Directory.GetFiles(FolderPath, "*.png");
        CloseSound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SoundControl()
    {
        ControlSound = !ControlSound;
        if (ControlSound)
        {
            AudioListener.pause = true;
            OpenSound();
        }
        else
        {
            AudioListener.pause = false;
            CloseSound();
        }
    }
    void OpenSound()
    {
        //讀取在streamingAsset資料夾內所有png圖檔的路徑病傳換成Byte，程式看得懂的方式
        byte[] pngBytes = System.IO.File.ReadAllBytes(filePaths[1]);
        //定義圖片
        Texture2D tex = new Texture2D(2, 2);
        //讀取圖片
        tex.LoadImage(pngBytes);
        //將Texture的圖片轉換成Sprite
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        //Sprite圖片帶入到按鈕
        SoundButton.sprite = fromTex;
    }
    void CloseSound()
    {
 
        byte[] pngBytes = System.IO.File.ReadAllBytes(filePaths[0]);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        SoundButton.sprite = fromTex;
    }
}
