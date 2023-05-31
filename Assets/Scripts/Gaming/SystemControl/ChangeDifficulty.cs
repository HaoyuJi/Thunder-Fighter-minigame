using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("自己开火间隔")]
    public FireLogic firelogic;

    [Tooltip("自己所受伤害")]
    public PlayerHealth playerhealth;

    [Tooltip("敌人生成速度")]
    public EnemyCreator enemycreator;

    [Tooltip("补给道具生成速度")]
    public PropCreator propcreator;

    void Awake()
    {
        if(GameData.Instance.param==0)
        {
            playerhealth.health = 10;
            playerhealth.Maxhealth = 10;
            enemycreator.interval = 3.5f;
            propcreator.Addtion_interval = 40;
            propcreator.Health_interval = 10;
        }
        else if(GameData.Instance.param == 1)
        {
            playerhealth.health = 7;
            playerhealth.Maxhealth = 7;
            enemycreator.interval = 2.8f;
            propcreator.Addtion_interval = 60;
            propcreator.Health_interval = 15;
        }
        else
        {
            playerhealth.health = 5;
            playerhealth.Maxhealth = 5;
            enemycreator.interval = 2f;
            propcreator.Addtion_interval = 80;
            propcreator.Health_interval = 20;
        }

        if(GameData.Instance.cheat)
        {
            playerhealth.health = 9999999999999999;
            playerhealth.Maxhealth = 9999999999999999;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
