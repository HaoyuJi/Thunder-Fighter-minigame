using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("�ӵ�Ԥ����")]
    public GameObject bulletPrefab;

    [Tooltip("�����ӵ�Ԥ����")]
    public GameObject otherbulletPrefab;

    [Tooltip("�����ӵ�Ԥ����")]
    public GameObject MAXbulletPrefab;

    [Tooltip("���������ӵ�Ԥ����")]
    public GameObject otherMAXbulletPrefab;

    [Tooltip("�ӵ��ڵ�Ĺ���")]
    public Transform bulletFolder;

    [Tooltip("�ӵ�������")]
    public Transform firePoint;

    [Tooltip("�ӵ��ķ���")]
    public Transform cannon;

    //[Tooltip("�ӵ������ٶ�")]
    //public float bulletSpeed ;

    //[Tooltip("�ӵ����о���")]
    //public float bulletDistance ;

    [Tooltip("�ӵ�������")]
    public float bulletInterval;

    [Tooltip("�ӵ���ЧԤ����")]
    public GameObject bulletSound;

    [Tooltip("����������ЧԤ����")]
    public GameObject upgradeSound;

    [Tooltip("�ӵ�ǿ����ЧԤ����")]
    public GameObject upgradeALLSound;

    int fire_count = 1, otherfire_count = 0;
    float[,] fire_way = {   { 0,0,0,0,0},
                            { -0.1f,0.1f,0,0,0},
                            {-0.2f,0,0.2f,0,0 },
                            { -0.3f,-0.1f,0.1f,0.3f,0},
                            { -0.4f, -0.2f,0, 0.2f, 0.4f } };
    float[,] otherfire_way = { { -10, 10, 0, 0, 0 ,0},
                                { -20, -10, 10, 20, 0,0 },
                                { -30, -20, -10, 10, 20, 30 } };
    void Start()
    {
        InvokeRepeating("TestFire", 0.1f, bulletInterval);
    }

    // Update is called once per frame
    void Update()
    {
        //����ģʽ
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (fire_count < 5)
                fire_count++;
            CancelInvoke("TestFire");
            InvokeRepeating("TestFire", 0.1f, bulletInterval);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (otherfire_count < 3)
                otherfire_count++;
            if (IsInvoking("TestFire2"))
                CancelInvoke("TestFire2");
            InvokeRepeating("TestFire2", 0.1f, bulletInterval);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            bulletPrefab = MAXbulletPrefab;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            otherbulletPrefab = otherMAXbulletPrefab;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("upgrade1"))
        {
            //������������
            Destroy(collision.gameObject);
            if (fire_count < 5)
                fire_count++;
            CancelInvoke("TestFire");
            InvokeRepeating("TestFire", 0.1f, bulletInterval);
            //��Ч
            Instantiate(upgradeSound, bulletFolder);
        }

        if (collision.name.StartsWith("upgrade2"))
        {
            //������������
            Destroy(collision.gameObject);
            if (otherfire_count < 3)
                otherfire_count++;
            if (IsInvoking("TestFire2"))
                CancelInvoke("TestFire2");
            InvokeRepeating("TestFire2", 0.1f, bulletInterval);
            //��Ч
            Instantiate(upgradeSound, bulletFolder);
        }

        if (collision.name.StartsWith("upgradeAll1"))
        {
            //������������
            Destroy(collision.gameObject);
            bulletPrefab = MAXbulletPrefab;
            //��Ч
            Instantiate(upgradeALLSound, bulletFolder);
        }

        if (collision.name.StartsWith("upgradeAll2"))
        {
            //������������
            Destroy(collision.gameObject);
            otherbulletPrefab = otherMAXbulletPrefab;
            //��Ч
            Instantiate(upgradeALLSound, bulletFolder);
        }

    }

    private void TestFire()
    {

        for (int i = 0; i < fire_count; i++)
        {
            Instantiate(bulletPrefab, this.firePoint.position+Vector3.right* fire_way[fire_count - 1, i], Quaternion.Euler(0, 0, 0), bulletFolder); // ָ�����ڵ�  
        }
        Instantiate(bulletSound, bulletFolder);
    }

    private void TestFire2()
    {
        for (int i = 0; i < 2 * otherfire_count; i++)
        {
            Instantiate(otherbulletPrefab, this.firePoint.position, Quaternion.Euler(0, 0, otherfire_way[otherfire_count - 1, i]), bulletFolder); // ָ�����ڵ�
            
        }

    }
}

