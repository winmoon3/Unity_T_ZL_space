using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("下一個場景的名稱")]
    public string Name;
    void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void NextScene()
    {
        //切換場景 Application.LoadLevel("下一個場景名稱");
        //Application.LoadLevel(1); 也可以輸入下一個場景的ID值
        //Application.LoadLevel("Video");
        //Application.loadedLevel取得當前關卡ID數值
        //Application.LoadLevel(Application.loadedLevel);重新遊戲
        Application.LoadLevel(Name);
    }
    public void Quit()
    {
        //Application.Quit();關閉遊戲
        Application.Quit();
    }
}

