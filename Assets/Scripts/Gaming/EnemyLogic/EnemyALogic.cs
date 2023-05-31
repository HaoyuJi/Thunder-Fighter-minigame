using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyALogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("y�����ٶ�")]
    public float Yspeed=-1;

    [Tooltip("����Ѫ��")]
    public float health;
    public float MAXhealth;

    [Tooltip("�ӵ�Ԥ����")]
    public GameObject bulletPrefab;

    //[Tooltip("�ӵ��ڵ�Ĺ���")]
    //public Transform bulletFolder;

    [Tooltip("�ӵ�������")]
    public Transform firePoint;

    //[Tooltip("�ӵ��ķ���")]
    //public Transform cannon;

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
        if (health <= 0 )
        {
            GameObject scoreObject = GameObject.Find("ScoreControl");
            ScoreLogic scoreLogic = scoreObject.GetComponent<ScoreLogic>();
            scoreLogic.addscore(100);
            Instantiate(Explode, this.transform.position, Quaternion.Euler(0, 0, 0), null);
            SelfDestroy();
            //��ը��Ч
            Instantiate(ExplodeSound, null);
        }
        else if(this.transform.position.y <= -8)
        {
            SelfDestroy();
        }
            
    }
    private void Movement()
    {
        this.transform.Translate(0, Yspeed*Time.deltaTime, 0, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.StartsWith("bullet"))
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
    private void TestFire()
    {

        Instantiate(bulletPrefab, this.firePoint.position, Quaternion.Euler(0, 0, 0),null); // ָ�����ڵ�

        //// ָ����ʼ�����ٶ�
        //BulletLogic script = node.GetComponent<BulletLogic>();
        //script.speed = bulletSpeed;
        //script.MaxDistance = bulletDistance;
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}