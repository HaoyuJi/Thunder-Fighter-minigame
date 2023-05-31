using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Y方向速度")]
    public float Yspeed=-1;

    [Tooltip("敌人血量")]
    public float health;
    public float MAXhealth;

    [Tooltip("子弹预制体")]
    public GameObject bulletPrefab;

    //[Tooltip("子弹节点的管理")]
    //public Transform bulletFolder;

    [Tooltip("子弹出生点")]
    public Transform firePoint;

    //[Tooltip("子弹飞行速度")]
    //public float bulletSpeed;

    //[Tooltip("子弹飞行距离")]
    //public float bulletDistance;

    [Tooltip("子弹发射间隔")]
    public float bulletInterval;

    [Tooltip("爆炸特效")]
    public GameObject Explode;

    [Tooltip("爆炸声效")]
    public GameObject ExplodeSound;

    [Tooltip("血条")]
    public GameObject HP_Bar;
    Image HP_Image;

    float[] fire_way = { -40, -20, 0, 20, 40 };

    void Start()
    {
        MAXhealth = health;
        HP_Image = HP_Bar.GetComponent<Image>();
        InvokeRepeating("TestFire", 0.1f, bulletInterval);
    }

    // Update is called once per frame
    void Update()
    {
        HP_Image.fillAmount = health / MAXhealth;
        Movement();
        if (health <= 0)
        {
            GameObject scoreObject = GameObject.Find("ScoreControl");
            ScoreLogic scoreLogic = scoreObject.GetComponent<ScoreLogic>();
            scoreLogic.addscore(500);
            Instantiate(Explode, this.transform.position, Quaternion.Euler(0, 0, 0), null);
            SelfDestroy();
            //爆炸声效
            Instantiate(ExplodeSound, null);
        }
        else if (this.transform.position.y <= -8)
        {
            SelfDestroy();
        }
    }
    private void Movement()
    {
        this.transform.Translate(0, Yspeed * Time.deltaTime, 0, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("bullet"))
        {
            //销毁子弹
            Destroy(collision.gameObject);
            health--;
        }
        if (collision.name.StartsWith("Laser"))
        {
            //销毁子弹
            Destroy(collision.gameObject);
            health -= 1.2f;
        }
        if (collision.name.StartsWith("Player"))
        {
            //被玩家撞了减少生命
            health -= 10f;
        }
    }
    private void TestFire()
    {
        for (int i = 0; i < fire_way.Length; i++)
        {
            Instantiate(bulletPrefab, this.firePoint.position ,Quaternion.Euler(0, 0, fire_way[i]), null); // 产生子弹
        }


    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
