using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("y�����ٶ�")]
    public float Yspeed;

    [Tooltip("x�����ٶ�")]
    public float Xspeed;

    [Tooltip("����Ѫ��")]
    public float health;
    public float MAXhealth;

    [Tooltip("�ӵ�Ԥ����1")]
    public GameObject bulletPrefab1;

    [Tooltip("�ӵ�Ԥ����2")]
    public GameObject bulletPrefab2;

    //[Tooltip("�ӵ��ڵ�Ĺ���")]
    //public Transform bulletFolder;

    [Tooltip("�ӵ�������")]
    public Transform firePoint;

    //[Tooltip("�ӵ������ٶ�")]
    //public float bulletSpeed;

    //[Tooltip("�ӵ����о���")]
    //public float bulletDistance;

    [Tooltip("�ӵ�������")]
    public float bulletInterval;

    [Tooltip("��ը��Ч")]
    public GameObject Explode;

    [Tooltip("��ը��Ч")]
    public GameObject ExplodeSound;

    [Tooltip("Ѫ��")]
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
            //��ը��Ч
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
            //�����ӵ�
            Destroy(collision.gameObject);
            health--;
        }
        if (collision.name.StartsWith("Laser"))
        {
            //�����ӵ�
            Destroy(collision.gameObject);
            health -= 1.2f;
        }
        if (collision.name.StartsWith("Player"))
        {
            //�����ײ�˼�������
            health -= 10f;
        }
    }
    private void TestFire1()
    {
        for (int i = 0; i < fire_way1.Length; i++)
        {

            Instantiate(bulletPrefab1, this.firePoint.position + Vector3.right * fire_way1[i], Quaternion.Euler(0, 0, 0), null); // �����ӵ�
        }
    }

    private void TestFire2()
    {
        for (int i = 0; i < fire_way2.Length; i++)
        {
            Instantiate(bulletPrefab2, this.firePoint.position, Quaternion.Euler(0, 0, fire_way2[i]), null); // �����ӵ�
        }
    }

    void SnakeMove()
    {
        // 4 ���ٶ�ѡ��
        float[] options = { -2,-1,0,1,2 };

        int x = Random.Range(0, options.Length);
        Xspeed = options[x];

    }
    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
