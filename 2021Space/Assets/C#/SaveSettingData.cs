using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//抓取外部資料
using System.IO;
////使用Unity新的UI程式庫
using UnityEngine.UI;
public class SaveSettingData : MonoBehaviour
{
    //在Awake寫入Save.txt的路徑
    string Path;
    //[Header("Test 文字")]
    //public Text TestText;
    //讀取文字檔，進行讀和寫入的功能
    FileStream file;
    [Header("Dropdown ScreenSize, Language")]
    public Dropdown ScreenSize, Language;
    void Awake()
    {
        //文字檔案路徑，Application.persistentDataPath使用此方法可以直接將資料進行讀寫，無需再進行轉檔處理
        Path = Application.persistentDataPath + "Save.txt";
        //Debug.Log(Path);
        //檢查此路徑是否有Save.txt檔案了，如果有會回傳true，否則回傳false
        if (File.Exists(Path))
        {
            //  TestText.text = "在手機已經建立過一個Save檔案";
        }
        else
        {
            // TestText.text = "在手機上尚未建立Save檔案，正在建立...";
            //在此路徑下建立一個文字檔，檔名為Save
            file = new FileStream(Path, FileMode.Create);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //WriteString("Hello");
        if (File.Exists(Path))
        {
            ReadString();
        }
    }
    public void SaveData()
    {
        WriteString(ScreenSize.value + "@" + Language.value);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void WriteString(string Data)
    {
        //找到Application.persistentDataPath路徑下的Save.txt並且開啟
        file = new FileStream(Path, FileMode.Open);
        //要開始將資料撰寫到Save.txt
        StreamWriter sw = new StreamWriter(file);
        //在txt中寫入要記錄的訊息
        sw.WriteLine(Data);
        //將寫入文件關閉
        sw.Close();

    }
    public void ReadString()
    {
        //Application.persistentDataPath路徑下的Save.txt所有文字
        //TestText.text = File.ReadAllText(Path);
        string Text = File.ReadAllText(Path);
        string[] Texts = Text.Split('@');
        ScreenSize.value = int.Parse(Texts[0]);
        Language.value = int.Parse(Texts[0]);
    }
}
