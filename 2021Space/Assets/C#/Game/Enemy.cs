using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("多久刪除")]
    public float Deletetime;
    [Header("速度")]
    public float Speed;
    public bool isenemy;
    [Header("每幾秒要產生一個子彈")]
    public float CreateTime;
    [Header("子彈")]
    public GameObject Bullet;
    [Header("子彈產生的位置")]
    public GameObject CreatePos;
    public GameObject VFX;
    // Start is called before the first frame update
    void Start()
    {
        //刪除物件寫法(要刪除的物件，多少時間自己消失)
        //gameObject代表有該腳本物件
        Destroy(gameObject, Deletetime);
        InvokeRepeating("CreateBullet", CreateTime, CreateTime);
    }
    void CreateBullet()
    {
        if(isenemy)
        // Debug.Log("產生子彈");
        Instantiate(Bullet, CreatePos.transform.position, CreatePos.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Staticvar.isStop)
            //Vector3.yp=(0,1,0) Vector3.down=(0,-1.0) Vector3.right=(1,0,0)......
            transform.Translate(Vector3.forward * Speed);
      
    }
    void OnTriggerEnter(Collider hit)
    {
       if (hit.GetComponent<Collider>().tag == "Player")
        {
            hit.GetComponent<Player>().HurtPlayer();
            Instantiate(VFX, hit.transform.position, hit.transform.rotation);
            Destroy(gameObject);
        } 
    }
}
