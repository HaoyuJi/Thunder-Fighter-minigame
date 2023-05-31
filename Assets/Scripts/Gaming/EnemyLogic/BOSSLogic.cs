using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSLogic : MonoBehaviour
{
    [Tooltip("x方向速度")]
    public float Xspeed;

    [Tooltip("Y方向速度")]
    public float Yspeed;

    [Tooltip("敌人血量")]
    public float health;
    float MAXhealth;

    [Tooltip("子弹预制体0")]
    public GameObject bulletPrefab0;

    [Tooltip("子弹预制体1")]
    public GameObject bulletPrefab1;

    [Tooltip("子弹预制体2")]
    public GameObject bulletPrefab2;

    [Tooltip("子弹预制体3")]
    public GameObject bulletPrefab3;

    [Tooltip("子弹预制体4")]
    public GameObject bulletPrefab4;

    [Tooltip("警告线预制体")]
    public GameObject CautionPrefab;

    [Tooltip("聚能预制体")]
    public GameObject GatherPrefab;

    //SpriteRenderer SR,SR1;
    //Color originColor;

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

    [Tooltip("机枪发射间隔")]
    public float machineInterval;

    [Tooltip("开火方式切换间隔")]
    public float ChangeInterval;

    [Tooltip("爆炸特效")]
    public GameObject Explode;

    [Tooltip("爆炸声效")]
    public GameObject ExplodeSound;

    [Tooltip("血条")]
    public GameObject HP_Bar;
    Image HP_Image;

    //选择开火方式索引
    int fireway_change_index = 0;

    //横向走位
    float[] options = { -15, -10, -5, 5, 10, 15, 0 };

    //开火方式
    float[] fire_way1 = { -3f, -1.5f, 0, 1.5f, 3f };
    float[] fire_way2 = { -40, -20, 0, 20, 40 };
    float[] fire_way3 = { -90,-60, -30, 0, 20, 40 };
    // Start is called before the first frame update
    void Start()
    {
        
        MAXhealth = health;
        HP_Image = HP_Bar.GetComponent<Image>();
        //SR = this.GetComponent<SpriteRenderer>();
        ////SR1 = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        //originColor = SR.color;
        InvokeRepeating("SnakeMove", 0, 2f);
        InvokeRepeating("FireControl",0,5);
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
            scoreLogic.addscore(100000);
            GameObject mainObject = GameObject.Find("MainControl");
            MainControl mainLogic = mainObject.GetComponent<MainControl>();
            mainLogic.Success();
            GameObject BGMbox = GameObject.Find("BGMbox");
            BGMControl BGMcontrol = BGMbox.GetComponent<BGMControl>();
            BGMcontrol.playSuccessBGM();
            Time.timeScale = 0.5f;
            Instantiate(Explode, this.transform.position, Quaternion.Euler(0, 0, 0), null);
            //爆炸声效
            Instantiate(ExplodeSound, null);
            SelfDestroy();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("bullet"))
        {
            //销毁子弹
            Destroy(collision.gameObject);
            //FlashColor();
            health--;
        }
        if (collision.name.StartsWith("Laser"))
        {
            //销毁子弹
            Destroy(collision.gameObject);
            //FlashColor();
            health -= 1.2f;
        }
        if (collision.name.StartsWith("Player"))
        {
            //被玩家撞了减少生命
            //FlashColor();
            health -= 10f;
        }
    }


    private void FireControl()
    {
        fireway_change_index = Random.Range(0, 5);
        if(fireway_change_index==0)
        {
            InvokeRepeating("TestFire0", 0.1f,  machineInterval);
            Invoke("CeaseFire0",3);
        }
        if (fireway_change_index == 1)
        {
            InvokeRepeating("TestFire1", 0.1f, bulletInterval);
            Invoke("CeaseFire1", 3);
        }
        if (fireway_change_index == 2)
        {
            InvokeRepeating("TestFire2", 0.1f, bulletInterval);
            Invoke("CeaseFire2", 3);
        }
        if (fireway_change_index == 3)
        {
            InvokeRepeating("TestFire3", 0.1f, bulletInterval*2);
            Invoke("CeaseFire3", 3);
        }
        if (fireway_change_index == 4)
        {
            CautionFire4();
            Invoke("TestFire4", 1.5f);
        }
    }

    private void TestFire0()
    {
           Instantiate(bulletPrefab0, this.firePoint.position, Quaternion.Euler(0, 0, 0), null); // 产生子弹
    }
    private void CeaseFire0()
    {
        CancelInvoke("TestFire0");
    }

    private void TestFire1()
    {
        for (int i = 0; i < fire_way1.Length; i++)
        {

            Instantiate(bulletPrefab1, this.firePoint.position + Vector3.right * fire_way1[i], Quaternion.Euler(0, 0, 0), null); // 产生子弹
        }
    }
    private void CeaseFire1()
    {
        CancelInvoke("TestFire1");
    }

    private void TestFire2()
    {
        for (int i = 0; i < fire_way2.Length; i++)
        {
            Instantiate(bulletPrefab2, this.firePoint.position, Quaternion.Euler(0, 0, fire_way2[i]), null); // 产生子弹
        }
    }
    private void CeaseFire2()
    {
        CancelInvoke("TestFire2");
    }

    private void TestFire3()
    {
        int count = 10;
        for (int i = 0; i < count; i++)
        {
            Instantiate(bulletPrefab3, this.firePoint.position, Quaternion.Euler(0, 0, i*(360/count)), null); // 产生子弹
        }

    }
    private void CeaseFire3()
    {
        CancelInvoke("TestFire3");
    }
    private void CautionFire4()
    {
        Instantiate(GatherPrefab, this.firePoint.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0), firePoint);
        Instantiate(CautionPrefab, this.firePoint.position + new Vector3(0, -8.7f, 0), Quaternion.Euler(0, 0, 0), firePoint);
    }
    private void TestFire4()
    {
        Instantiate(bulletPrefab4, this.firePoint.position+new Vector3(0, -4.5f,0), Quaternion.Euler(0, 0, 0), firePoint); // 产生子弹
    }




    private void Movement()
    {
        float dx = Xspeed * Time.deltaTime;
        float dy = Yspeed * Time.deltaTime;
        if (this.transform.position.x < -8.5f && dx < 0 || this.transform.position.x > 5.5f && dx > 0)
        {
            dx = 0;
        }
        if (this.transform.position.y < 1.3f && dy < 0 || this.transform.position.y > 3.58f && dy > 0)
        {
            dy = 0;
        }
        this.transform.Translate(dx, dy, 0, Space.World);
    }

    void SnakeMove()
    {
        // 4 种速度选项
        float[] optionsx = { -5f, -3f, 0, 3f, 5f };
        float[] optionsy = { -1, -0.5f, 0, 0.5f, 1 };
        int x = Random.Range(0, optionsx.Length);
        int y = Random.Range(0, optionsy.Length);
        Xspeed = optionsx[x];
        Yspeed = optionsy[y];

    }
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }

    //void FlashColor()
    //{
    //    //分别对应着R,G,B,透明度
    //    SR.color = new Color(255, 255, 255, 0);
    //    //SR1.color = new Color(255, 0, 255, 255);
    //    if (IsInvoking("ResetColor"))
    //        CancelInvoke("ResetColor");
    //        Invoke("ResetColor", 0.05f);
    //}

    //void ResetColor()
    //{
    //    SR.color = originColor;
    //    //SR1.color= originColor;
    //}

}
