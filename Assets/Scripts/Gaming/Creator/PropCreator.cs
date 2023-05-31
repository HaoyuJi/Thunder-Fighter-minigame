using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("加成道具库")]
    public GameObject[] AddtionProp;

    [Tooltip("升级道具库")]
    public GameObject[] LevelupProp;

    [Tooltip("强力升级道具库")]
    public GameObject[] LevelupmoreProp;

    [Tooltip("血量道具库")]
    public GameObject HealthProp;

    [Tooltip("定时创建新的加成道具")]
    public float Addtion_interval;

    [Tooltip("定时创建新的升级道具")]
    public float Levelup_interval;

    [Tooltip("定时创建新的血量道具")]
    public float Health_interval;

    [Tooltip("强力升级道具CD")]
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

        // 添加一个随机的偏移量，避免被人堵住出生点
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
    }
    private void HealthPropCreate()
    {
        GameObject Prop = Instantiate(HealthProp, this.transform);
        Prop.transform.position = this.transform.position;

        // 添加一个随机的偏移量，避免被人堵住出生点
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
    }

    private void LevelupPropCreate()
    {
        prop_index = Random.Range(0, LevelupProp.Length);
        GameObject Prop = Instantiate(LevelupProp[prop_index], this.transform);
        Prop.transform.position = this.transform.position;

        // 添加一个随机的偏移量，避免被人堵住出生点
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
    }

    private void LevelupmorePropCreate()
    {
        GameObject Prop = Instantiate(LevelupmoreProp[MAX_index], this.transform);
        Prop.transform.position = this.transform.position;

        // 添加一个随机的偏移量，避免被人堵住出生点
        float dx = Random.Range(-9.0f, 9.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        Prop.transform.Translate(dx, dy, 0, Space.Self);
        MAX_index = 1;
    }
}
