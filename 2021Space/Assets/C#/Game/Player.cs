using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("玩家移動速度")]
    public float Speed;
    [Header("XY位置最大值/最小值")]
    public float MaxX, MinX, MaxY, MinY;

    [Header("每幾秒要產生一個子彈")]
    public float CreateTime;
    [Header("子彈")]
    public GameObject Bullet;
    [Header("子彈產生的位置")]
    public GameObject CreatePos;
    public float TotalHP;
    public float HurtHP;
     float ScriptHP;
    public Image PlayerHPBar;
    public void HurtPlayer()
    {
        //玩家扣们 ScriptHP -=HurtHD
        ScriptHP = ScriptHP - HurtHP;
        //玩家血量顯示在UT上
        PlayerHPBar.fillAmount= ScriptHP / TotalHP;
        


    }

    // Start is called before the first frame update
    void Start()
    {
        ScriptHP = TotalHP;
        //InvokeRepeating遊戲執行後持續呼叫function("要被呼叫的function名稱",程式執行以後幾秒鐘呼叫第一次，固定間隔幾秒鐘呼叫)
        InvokeRepeating("CreateBullet", CreateTime, CreateTime);
    }
    void CreateBullet() {
        // Debug.Log("產生子彈");
        Instantiate(Bullet, CreatePos.transform.position, CreatePos.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        #region 遊戲位移說明
        /*  if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
          {
              transform.Translate(0, 1, 0);
          }
          if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
          {
              transform.Translate(0, -1, 0);
          }
          if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
          {
              transform.Translate(-1, 0, 0);
          }
          if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
          {
              transform.Translate(1, 0, 0);
          }*/
        #endregion
        //透過軸向方式控制玩家位移
        transform.Translate(Input.GetAxis("Horizontal")*Speed, 0, Input.GetAxis("Vertical")*Speed);
        //限制式Mathf.Clamp(要限制的參數,最小值,最大值)
        //Vector3 3維座標
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), -0.35f);
        //如果玩家沒血，跳至遊戲結束場景
        if (ScriptHP <= 0)
        {
            GameObject.Find("GM").GetComponent<GameManager>().SaveScoreData();
            //SceneManager.LoadScene("GameOver"):
            Application.LoadLevel("GameOver");

        }

    }

}
