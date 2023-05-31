using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("y方向速度")]
    public float Yspeed;

    [Tooltip("x方向速度")]
    public float Xspeed;

    [Tooltip("敌人血量")]
    public float health;
    public float MAXhealth;

    [Tooltip("子弹预制体1")]
    public GameObject bulletPrefab1;

    [Tooltip("子弹预制体2")]
    public GameObject bulletPrefab2;

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

    float[] options = { -15, -10, -5, 5, 10, 15, 0 };
    float[] fire_way1 = { -3f, -1.5f, 0, 1.5f, 3f };
    float[] fire_way2 = { -40, -20, 0, 20, 40 };
   

    void Start()
    {
        MAXhealth = health;
        HP_Image = HP_Bar.GetComponent<Image>();
        InvokeRepeating("SnakeMove", 1f, 1f);
        InvokeRepeating("TestFire1", 0.1f, 2*bulletInterval);
        InvokeRepeating("TestFire2", bulletInterval+ 0.1f, 2*bulletInterval);
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
            scoreLogic.addscore(5000);
            Instantiate(Explode, this.transform.position, Quaternion.Euler(0, 0, 0), null);
            //爆炸声效
            Instantiate(ExplodeSound, null);
            SelfDestroy();
        }
        else if (this.transform.position.y <= -8)
        {
            SelfDestroy();
        }
    }
    private void Movement()
    {
        float dx = Xspeed * Time.deltaTime;
        if (this.transform.position.x < -8.5f && dx < 0 || this.transform.position.x > 8.5f && dx > 0)
        {
            dx = 0;
        }
        this.transform.Translate(dx, Yspeed * Time.deltaTime, 0, Space.World);
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
    private void TestFire1()
    {
        for (int i = 0; i < fire_way1.Length; i++)
        {

            Instantiate(bulletPrefab1, this.firePoint.position + Vector3.right * fire_way1[i], Quaternion.Euler(0, 0, 0), null); // 产生子弹
        }
    }

    private void TestFire2()
    {
        for (int i = 0; i < fire_way2.Length; i++)
        {
            Instantiate(bulletPrefab2, this.firePoint.position, Quaternion.Euler(0, 0, fire_way2[i]), null); // 产生子弹
        }
    }

    void SnakeMove()
    {
        // 4 种速度选项
        float[] options = { -2,-1,0,1,2 };

        int x = Random.Range(0, options.Length);
        Xspeed = options[x];

    }
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
