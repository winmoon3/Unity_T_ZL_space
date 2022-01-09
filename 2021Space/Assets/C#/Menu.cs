using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用Unity UI程式庫
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [Header("擺放BGM的Prefab物件")]
    public GameObject BGM;

    [Header("控制聲音開關")]
    public bool ControlSound;
   /* [Header("開聲音的圖片")]
    public Sprite OpenSoundTex;
    [Header("關聲音的圖片")]
    public Sprite CloseSoundTex;*/
    [Header("放入聲音的按鈕")]
    public Image SoundButton;

    [Header("控制解析度的下拉選單")]
    public Dropdown ScreenSizeDropdown;

    [Header("語言的下拉選單")]
    public Dropdown LanguageDropdown;
    //保存LanguageDropdown的ID數值
    static public int LanguageID;
    [Header("擺放BGM的Prefab物件")]
    public GameObject ReadText;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("物件名稱")
        //GameObject.FindWithTag("物件標籤")
        //找尋場景上是否有BGM物件，如果找尋BGM數量為0，代表場景上沒有任何BGM物件
        if (GameObject.FindGameObjectsWithTag("BGM").Length<=0) {
            //Instantiate動態生成(要生成的物件)
            Instantiate(BGM);
        }
        if (GameObject.FindGameObjectsWithTag("ReadText").Length <= 0)
        {
            //Instantiate動態生成(要生成的物件)
            Instantiate(ReadText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SoundControl() {
    //!反義
        ControlSound = !ControlSound;
        //if (ControlSound == true)
        if (ControlSound)
        {
            //聲音要暫停
            AudioListener.pause = true;
            //圖片要換成關聲音的圖片
            // SoundButton.sprite = CloseSoundTex;
            SoundButton.sprite = Resources.Load<Sprite>("soundOpen");
        }
        else {
            //聲音要開啟
            AudioListener.pause = false;
            //圖片要換成開聲音的圖片
            //SoundButton.sprite = OpenSoundTex;
            SoundButton.sprite = Resources.Load<Sprite>("images");
        }
    }
    public void ChangeScreenSize() {
        /* if (ScreenSizeDropdown.value == 0)
         {
             // Screen.SetResolution(螢幕寬,螢幕高,要不要全螢幕);
             Screen.SetResolution(1080, 1920, false);
         }
         else
         {
             Screen.SetResolution(480, 800, false);
         }*/

        switch (ScreenSizeDropdown.value) {
            case 0:
                Screen.SetResolution(1080, 1920, false);
                break;
            case 1:
                Screen.SetResolution(480, 800, false);
                break;
        }
    }
    public void ChangeLanguage() {
        LanguageID = LanguageDropdown.value;
    }
}
