using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("子弹预制体")]
    public GameObject bulletPrefab;

    [Tooltip("附加子弹预制体")]
    public GameObject otherbulletPrefab;

    [Tooltip("升级子弹预制体")]
    public GameObject MAXbulletPrefab;

    [Tooltip("升级附加子弹预制体")]
    public GameObject otherMAXbulletPrefab;

    [Tooltip("子弹节点的管理")]
    public Transform bulletFolder;

    [Tooltip("子弹出生点")]
    public Transform firePoint;

    [Tooltip("子弹的方向")]
    public Transform cannon;

    //[Tooltip("子弹飞行速度")]
    //public float bulletSpeed ;

    //[Tooltip("子弹飞行距离")]
    //public float bulletDistance ;

    [Tooltip("子弹发射间隔")]
    public float bulletInterval;

    [Tooltip("子弹声效预制体")]
    public GameObject bulletSound;

    [Tooltip("弹道升级声效预制体")]
    public GameObject upgradeSound;

    [Tooltip("子弹强化声效预制体")]
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
        //作弊模式
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
            //销毁升级道具
            Destroy(collision.gameObject);
            if (fire_count < 5)
                fire_count++;
            CancelInvoke("TestFire");
            InvokeRepeating("TestFire", 0.1f, bulletInterval);
            //声效
            Instantiate(upgradeSound, bulletFolder);
        }

        if (collision.name.StartsWith("upgrade2"))
        {
            //销毁升级道具
            Destroy(collision.gameObject);
            if (otherfire_count < 3)
                otherfire_count++;
            if (IsInvoking("TestFire2"))
                CancelInvoke("TestFire2");
            InvokeRepeating("TestFire2", 0.1f, bulletInterval);
            //声效
            Instantiate(upgradeSound, bulletFolder);
        }

        if (collision.name.StartsWith("upgradeAll1"))
        {
            //销毁升级道具
            Destroy(collision.gameObject);
            bulletPrefab = MAXbulletPrefab;
            //声效
            Instantiate(upgradeALLSound, bulletFolder);
        }

        if (collision.name.StartsWith("upgradeAll2"))
        {
            //销毁升级道具
            Destroy(collision.gameObject);
            otherbulletPrefab = otherMAXbulletPrefab;
            //声效
            Instantiate(upgradeALLSound, bulletFolder);
        }

    }

    private void TestFire()
    {

        for (int i = 0; i < fire_count; i++)
        {
            Instantiate(bulletPrefab, this.firePoint.position+Vector3.right* fire_way[fire_count - 1, i], Quaternion.Euler(0, 0, 0), bulletFolder); // 指定父节点  
        }
        Instantiate(bulletSound, bulletFolder);
    }

    private void TestFire2()
    {
        for (int i = 0; i < 2 * otherfire_count; i++)
        {
            Instantiate(otherbulletPrefab, this.firePoint.position, Quaternion.Euler(0, 0, otherfire_way[otherfire_count - 1, i]), bulletFolder); // 指定父节点
            
        }

    }
}

