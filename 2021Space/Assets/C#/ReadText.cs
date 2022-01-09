using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//抓取外部資料
using System.IO;
//使用Unity新的UI程式庫
using UnityEngine.UI;
public class ReadText : MonoBehaviour
{
    [Header("讀取中文文字檔案")]
    public string CHMassage;
    [Header("讀取英文文字檔案")]
    public string ENMassage;
    //中文文字檔的路徑
    string CHPath;
    //英文文字檔的路徑
    string ENPath;
    [Header("儲存每行中文文字")]
    public string[] CHTexts;
    [Header("儲存每行英文文字")]
    public string[] ENTexts;

    WWW CHreader;
    WWW ENreader;
    void Awake()
    {

        //中文文字檔在StreamingAssets資料夾內的路徑
        CHPath = Application.streamingAssetsPath + "/CH.txt";
        //英文文字檔在StreamingAssets資料夾內的路徑
        ENPath = Application.streamingAssetsPath + "/EN.txt";
        //如果現在執行的平台為Android
        if (Application.platform == RuntimePlatform.Android)
        {
            //透過網址方式把StreamingAssets資料夾內的路徑轉檔
             CHreader = new WWW(CHPath);
            //並讀取網址內的文字訊息
             ENreader = new WWW(ENPath);
            //將字串文字切割 字串.Split('需要切割的符號')
            CHTexts = CHreader.text.Split('\n');
            ENTexts = ENreader.text.Split('\n');
        }
        else
        {
            //讀取中文文字檔內所有的文字
            CHMassage = File.ReadAllText(CHPath);
            //讀取英文文字檔內所有的文字
            ENMassage = File.ReadAllText(ENPath);
            //將字串文字切割 字串.Split('需要切割的符號')
            CHTexts = CHMassage.Split('\n');
            ENTexts = ENMassage.Split('\n');
        }
        //Debug.Log(CHMassage);
        //Debug.Log(ENMassage);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
