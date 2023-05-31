using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("���Ѫ��")]
    public float health;
    public float Maxhealth;

    [Tooltip("Ѫ��")]
    public GameObject HP_Bar;

    [Tooltip("����ʧ��ͼ��")]
    public GameObject Missionfail;

    [Tooltip("��ը��Ч")]
    public GameObject Explode;

    [Tooltip("��ը��Ч")]
    public GameObject ExplodeSound;

    public float losehealth;

    [Tooltip("��Ѫ��ЧԤ����")]
    public GameObject HittedSound;

    [Tooltip("��Ѫ������ЧԤ����")]
    public GameObject HealthSound;

    [Tooltip("�Ӷܵ�����ЧԤ����")]
    public GameObject  ShieldSound;

    Image HP_Image;
    Transform child;

    //��ҵ���Ⱦ����ɫ
    SpriteRenderer SR0, SR1,SR2, SR3,SR4;
    Color originColor;

    //��ײ��
    BoxCollider2D box;
    void Start()
    {
        box = this.GetComponent<BoxCollider2D>();
        SR0 = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        SR1 = this.transform.GetChild(1).GetComponent<SpriteRenderer>();
        SR2 = this.transform.GetChild(2).GetComponent<SpriteRenderer>();
        SR3 = this.transform.GetChild(3).GetComponent<SpriteRenderer>();
        SR4 = this.transform.GetChild(4).GetComponent<SpriteRenderer>();
        originColor = SR0.color;
        child = this.transform.GetChild(6);
        HP_Image = HP_Bar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health> Maxhealth)
        {
            HP_Image.fillAmount = Maxhealth/10f;
            child.gameObject.SetActive(true);
        }
            
        else if(health <= Maxhealth)
        {
            HP_Image.fillAmount = health / 10f;
            child.gameObject.SetActive(false);
            if (health <= 0)
            {
                SelfDestroy();
                Instantiate(Explode, this.transform.position , Quaternion.Euler(0, 0, 0), null);
                GameObject BGMbox = GameObject.Find("BGMbox");
                BGMControl BGMcontrol = BGMbox.GetComponent<BGMControl>();
                BGMcontrol.playFailBGM();
                Missionfail.SetActive(true);
                //��ը��Ч
                Instantiate(ExplodeSound, null);
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Ebullet"))
        {
            //���ٵз��ӵ�
            Destroy(collision.gameObject);
            health=health-losehealth;
            //������˸�������޵�1.6s
            if(health<Maxhealth)
                Startflash();
            Instantiate(HittedSound, null);
        }

        if (collision.name.StartsWith("ELaser"))
        {
            //��������
            health = health - 2*losehealth;
            if (health < Maxhealth)
                Startflash();
            Instantiate(HittedSound, null);

        }
        if (collision.name.StartsWith("Enemy"))
        {
            //��������
            health = health - losehealth;
            if (health < Maxhealth)
                Startflash();
            Instantiate(HittedSound, null);
        }
        if (collision.name.StartsWith("health"))
        {
            //���ٵ���
            Destroy(collision.gameObject);
            if(health< Maxhealth)
                health++;
            Instantiate(HealthSound, null);
        }
        if (collision.name.StartsWith("shield"))
        {
            //���ٵ���
            Destroy(collision.gameObject);
            //if (health <= 3)
            health = Maxhealth + 2;
            //else health = health + 2;
            Instantiate(ShieldSound, null);
        }
    }


    //������˸�������޵�1.6s
    void Startflash()
    {
        box.enabled = false;
        InvokeRepeating("Flashonstrike",0,0.25f);
        Invoke("CancelFlash", 1.6f);
    }
    void Flashonstrike()
    {
        //�ֱ��Ӧ��R,G,B,͸����
        if (SR0.color== originColor)
        {
            SR0.color = new Color(255, 255, 255, 0);
            SR1.color = new Color(255, 255, 255, 0);
            SR2.color = new Color(255, 255, 255, 0);
            SR3.color = new Color(255, 255, 255, 0);
            SR4.color = new Color(255, 255, 255, 0);
        }
        else
        {
         
            SR0.color = originColor;
            SR1.color = originColor;
            SR2.color = originColor;
            SR3.color = originColor;
            SR4.color = originColor;

        }

    }

    void CancelFlash()
    {
        CancelInvoke("Flashonstrike");
        SR0.color = originColor;
        SR1.color = originColor;
        SR2.color = originColor;
        SR3.color = originColor;
        SR4.color = originColor;
        //˳�����ײ���
        box.enabled = true;

    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
