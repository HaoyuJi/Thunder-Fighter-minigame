using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("A���˿�")]
    public GameObject[] enemyPrefabA;

    [Tooltip("B���˿�")]
    public GameObject[] enemyPrefabB;

    [Tooltip("C���˿�")]
    public GameObject[] enemyPrefabC;

    [Tooltip("D���˿�")]
    public GameObject[] enemyPrefabD;

    [Tooltip("��ʱ�����µĹ���")]
    public float interval;

    int enemy_index;

    void Start()
    {
        Debug.Log("��ʼ��");
        InvokeRepeating("CreateEnemyA", 0.1f, interval);
        InvokeRepeating("CreateEnemyB", 25, interval*2.5f);
        InvokeRepeating("CreateEnemyC", 60, interval * 3.5f);
        InvokeRepeating("CreateEnemyD", 120, interval * 15);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreateEnemyA()
    {
        enemy_index = Random.Range(0, enemyPrefabA.Length);
        GameObject node = Instantiate(enemyPrefabA[enemy_index], this.transform);
        node.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.6f, 9.6f);
        node.transform.Translate(dx, 0, 0, Space.Self);

    }

    private void CreateEnemyB()
    {
        enemy_index = Random.Range(0, enemyPrefabB.Length);
        GameObject node = Instantiate(enemyPrefabB[enemy_index], this.transform);
        node.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.6f, 9.6f);
        node.transform.Translate(dx, 0, 0, Space.Self);

    }

    private void CreateEnemyC()
    {
        enemy_index = Random.Range(0, enemyPrefabC.Length);
        GameObject node = Instantiate(enemyPrefabC[enemy_index], this.transform);
        node.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.6f, 9.6f);
        node.transform.Translate(dx, 0, 0, Space.Self);

    }

    private void CreateEnemyD()
    {
        enemy_index = Random.Range(0, enemyPrefabD.Length);
        GameObject node = Instantiate(enemyPrefabD[enemy_index], this.transform);
        node.transform.position = this.transform.position;

        // ���һ�������ƫ���������ⱻ�˶�ס������
        float dx = Random.Range(-9.6f, 9.6f);
        node.transform.Translate(dx, -0.5f, 0, Space.Self);

    }
}
