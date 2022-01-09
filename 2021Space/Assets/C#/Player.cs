using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("move speed")]
    public float Speed;
    [Header("XY位置最大值/最小值")]
    public float MaxX, MinX, MaxY, MinY;

    [Header("BulletcreateTime.S")]
    public float createTime;
    [Header("Bullet")]
    public GameObject Bullet;
    [Header("BulletCreatePos")]
    public GameObject CreatePos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBullet", createTime, createTime);
    }

    // Update is called once per frame
    void CreateBullet()
    {
        //Debug.Log(" 產生子彈”)
        Instantiate(Bullet, CreatePos.transform.position, CreatePos.transform.rotation);
}

    void Update()
    {
       // transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //透遹軸向方式控制玩家位移
        transform.Translate(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed);
        //限制式Nathf.clamp（要限制的參败，最小值，最大值)
        //vector3 3維座標
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), -0.35f);

    }
}
