using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//抓取外部資料
using System.IO;
//使用Unity新的UI程式庫
using UnityEngine.UI;

public class Loadtxt : MonoBehaviour
{
   
    [Header("讀取該文字在陣列中的代號")]
    public int TextID;
      
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ReadText").Length > 0)
        {
            //讀取語言下拉選單的ID
            if (Menu.LanguageID == 0)
            {
                //讀取第幾個陣列的中文文字
                GetComponent<Text>().text = GameObject.FindGameObjectWithTag("ReadText").GetComponent<ReadText>().CHTexts[TextID];
            }
            if (Menu.LanguageID == 1)
            {
                //讀取第幾個陣列的英文文字
                GetComponent<Text>().text = GameObject.FindGameObjectWithTag("ReadText").GetComponent<ReadText>().ENTexts[TextID];
            }
        }
    }
}
