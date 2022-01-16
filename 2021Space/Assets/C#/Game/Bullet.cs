using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("子彈若沒擊中多久刪除")]
    public float Deletetime;
    [Header("子彈速度")]
    public float Speed;
    public GameObject VFX;
    // Start is called before the first frame update
    void Start()
    {
        //刪除物件寫法(要刪除的物件，多少時間自己消失)
        //gameObject代表有該腳本物件
        Destroy(gameObject, Deletetime);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.yp=(0,1,0) Vector3.down=(0,-1.0) Vector3.right=(1,0,0)......
        transform.Translate(Vector3.up * Speed);
    }
    void OnTriggerEnter(Collider hit)
    {
        //player hit Enemy
        if (hit.GetComponent<Collider>().tag == "enemy" && gameObject.tag == "player bullet")
        {
            GameObject.Find("GM").GetComponent<GameManager>().Score();
            Instantiate(VFX, hit.transform.position, hit.transform.rotation);
            Destroy(hit.GetComponent<Collider>().gameObject);
            Destroy(gameObject);
        }
            //Enemy hit player
            if (hit.GetComponent<Collider>().tag == "player" && gameObject.tag == "enemy bullet")
            {
            hit.GetComponent<Player>().HurtPlayer();
            Instantiate(VFX, hit.transform.position, hit.transform.rotation);
                Destroy(gameObject);
            }
            
    }
}
