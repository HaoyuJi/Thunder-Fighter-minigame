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
    [Tooltip("改变难度的文字")]
    public Text difficultyText;
    [Tooltip("作弊模式的文字")]
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
            difficultyText.text = "选择难度：简单";
        else if(difficulty==1)
            difficultyText.text = "选择难度：普通";
        else difficultyText.text = "选择难度：困难";
    }
    public void CheatingorNot()
    {
        cheat = !cheat;
        GameData.Instance.cheat = cheat;
        if (cheat==true)
            cheatText.text = "无敌模式：开启";
        else
            cheatText.text = "无敌模式：关闭";
    }

    //public MainmenuControl()
    //{
    //    Debug.Log("GameStart");
    //}
}
