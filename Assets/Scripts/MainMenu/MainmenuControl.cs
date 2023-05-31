using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainmenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int difficulty = 0;
    public bool cheat=false;
    [Tooltip("�ı��Ѷȵ�����")]
    public Text difficultyText;
    [Tooltip("����ģʽ������")]
    public Text cheatText;
    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        difficulty = 0;
        GameData.Instance.param = difficulty;
        cheat = false;
        GameData.Instance.cheat = cheat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startgame()
    {
        SceneManager.LoadScene("Gaming");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeDifficulty()
    {
        if (difficulty < 2) difficulty++;
        else difficulty = 0;
        GameData.Instance.param = difficulty;

        if (difficulty == 0)
            difficultyText.text = "ѡ���Ѷȣ���";
        else if(difficulty==1)
            difficultyText.text = "ѡ���Ѷȣ���ͨ";
        else difficultyText.text = "ѡ���Ѷȣ�����";
    }
    public void CheatingorNot()
    {
        cheat = !cheat;
        GameData.Instance.cheat = cheat;
        if (cheat==true)
            cheatText.text = "�޵�ģʽ������";
        else
            cheatText.text = "�޵�ģʽ���ر�";
    }

    //public MainmenuControl()
    //{
    //    Debug.Log("GameStart");
    //}
}
