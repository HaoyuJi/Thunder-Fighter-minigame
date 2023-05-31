using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("�ӳɵ��߿�")]
    public GameObject[] AddtionProp;

    [Tooltip("�������߿�")]
    public GameObject[] LevelupProp;

    [Tooltip("ǿ���������߿�")]
    public GameObject[] LevelupmoreProp;

    [Tooltip("Ѫ�����߿�")]
    public GameObject HealthProp;

    [Tooltip("��ʱ�����µļӳɵ���")]
    public float Addtion_interval;

    [Tooltip("��ʱ�����µ���������")]
    public float Levelup_interval;

    [Tooltip("��ʱ�����µ�Ѫ������")]
    public float Health_interval;

    [Tooltip("ǿ����������CD")]
    public float Levelupmore_interval;

    int prop_index;int MAX_index = 0;
    void Start()
    {
        InvokeRepeating("AddtionPropCreate", Addtion_interval/2, Addtion_interval);
        InvokeRepeating("HealthPropCreate", Health_interval/2, Health_interval);
        InvokeRepeating("LevelupPropCreate", Levelup_interval / 2, Levelup_interval);
        Invoke("LevelupmorePropCreate", Levelupmore_interval);
        Invoke("LevelupmorePropCreate", Levelupmore_interval*2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddtionPropCreate ()
    {
        prop_index = Random.Range(0, AddtionProp.Length);
        GameObject Prop = Instantiate(AddtionProp[prop_index], this.transform);
        Prop.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
    }
    private void HealthPropCreate()
    {
        GameObject Prop = Instantiate(HealthProp, this.transform);
        Prop.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
    }

    private void LevelupPropCreate()
    {
        prop_index = Random.Range(0, LevelupProp.Length);
        GameObject Prop = Instantiate(LevelupProp[prop_index], this.transform);
        Prop.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
    }

    private void LevelupmorePropCreate()
    {
        GameObject Prop = Instantiate(LevelupmoreProp[MAX_index], this.transform);
        Prop.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
        MAX_index = 1;
    }
}
