using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    // Start is called before the first frame update
    int m_index = 0, last_index=0; // 表示显示的是飞机哪一个姿态
    float lastpositionX = 0;

    [Tooltip("引用主控中的函数")]
    public MainControl main;

    int count;
    Transform child;
    void Start()
    {
        count = this.transform.childCount;
        InvokeRepeating("ChangeShape", 0.1f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    private void ChangeShape()
    {
        if(this.transform.position.x < lastpositionX)
        {
            if (last_index == 1)
                m_index = 2;
            else m_index = 1;
           
        }
        else if(this.transform.position.x > lastpositionX)
        {
            if (last_index == 3)
                m_index = 4;
            else m_index = 3;
        }
        else
        {
            if (last_index == 2)
                m_index = 1;
            else if (last_index == 4)
                m_index = 3;
            else
                m_index = 0;
        }
        // 先把原来的形状，隐藏
        child = this.transform.GetChild(last_index);
        child.gameObject.SetActive(false);
   
        // 显示新的形状
        child = this.transform.GetChild(m_index);
        child.gameObject.SetActive(true);
        lastpositionX = this.transform.position.x;
        last_index = m_index;
    }
    private void PlayerControl()
    {
        if(Time.timeScale==1)
        {

            Vector3 mouse_screen_pos = Input.mousePosition;
            Vector3 mouse_world_pos = Camera.main.ScreenToWorldPoint(mouse_screen_pos);
            if (mouse_world_pos.x >= 9.8f || mouse_world_pos.x <= -9.8f)
                mouse_world_pos.x = this.transform.position.x;
            if (mouse_world_pos.y >= 5.3f || mouse_world_pos.y <= -5.3f)
                mouse_world_pos.y = this.transform.position.y;

            this.transform.position = new Vector3(mouse_world_pos.x, mouse_world_pos.y, this.transform.position.z);
        }
     
    }
}
