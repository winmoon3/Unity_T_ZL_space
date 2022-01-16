using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
     void Awake()
    {
        // DontDestroyOnLoad在切換場景時不要刪除物件(物件項目);
        //gameObject指的是物件本身自己
        DontDestroyOnLoad(gameObject);
    }
     void Update()
    {
        //gameObject.name抓取自己身上的物件名稱
        //gameObject.tag抓取自己身上的物件標籤
        //如果物件標籤為BGM才去控制聲音元件
        if (gameObject.tag == "BGM")
        {
            //如果場景名稱為Video
            if (Application.loadedLevelName == "Video")
            {
                //抓取BGM物件的AudioSource，將Mute靜音功能開啟
                GetComponent<AudioSource>().mute = true;
            }
            //如果不為Video場景名稱
            else
            {
                //靜音選項關閉
                GetComponent<AudioSource>().mute = false;
            }
        }
    }
}
