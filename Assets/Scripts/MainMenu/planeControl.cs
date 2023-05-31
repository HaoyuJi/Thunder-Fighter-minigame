using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeControl : MonoBehaviour
{
    // Start is called before the first frame update
    int m_index = 0;int m_index_index = 0;
    bool shield_bool = false;
    int count;
    Transform child;
    Transform shield;
    void Start()
    {
        count = this.transform.childCount-2;
        InvokeRepeating("ChangeShape", 0.1f, 0.3f);
        InvokeRepeating("Shieldchange", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeShape()
    {

        // 先把原来的形状，隐藏
        child = this.transform.GetChild(m_index);
        child.gameObject.SetActive(false);
        if(m_index==0)
        {
            m_index_index++;
            if (m_index_index >= 10)
            {
                m_index_index = 0;
                m_index++;
            }
        }
        else m_index++;
        if (m_index >= count)
            m_index = 0;
        // 显示新的形状
        child = this.transform.GetChild(m_index);
        child.gameObject.SetActive(true);
    }

    private void Shieldchange()
    {
        shield = this.transform.GetChild(count+1);
        shield_bool = !shield_bool;
        shield.gameObject.SetActive(shield_bool);
    }
}
