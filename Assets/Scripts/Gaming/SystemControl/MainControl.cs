using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;

    [Tooltip("总时间")]
    public float GameDuration;

    [Tooltip("怪物生成点")]
    public GameObject EnemyCreator;

    [Tooltip("BOSS生成点")]
    public GameObject BOSSCreator;

    [Tooltip("道具生成点")]
    public GameObject PropCreator;

    [Tooltip("剩余时间显示")]
    public Text timeText;

    [Tooltip("成功界面显示")]
    public GameObject success;

    [Tooltip("BGM播放器")]
    public AudioSource BGMplayer;

    [Tooltip("警告声效预制体")]
    public GameObject WarningSound;

    //MainmenuControl mainmenuControl;


    bool setact = false;
    float timescale = 0;int time;
    void Start()
    {
        //mainmenucontrol = new mainmenucontrol();
        Application.targetFrameRate = 120;
        Invoke("DestroyAll", GameDuration);
        Time.timeScale = 1;
        timeText.text = "剩余时间: " + GameDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
        Timeleft();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
        }
    }
    void StopGame()
    {
        Time.timeScale = timescale;
        if (BGMplayer.isPlaying) BGMplayer.Pause();
        else BGMplayer.Play();
        if (timescale == 0) timescale = 1;
        else timescale = 0;
        setact = !setact;
        Menu.SetActive(setact);
    }
    public void DestroyAll()
    {
        BOSSCreator.SetActive(true);
        Instantiate(WarningSound, BOSSCreator.transform);
        Destroy(EnemyCreator);
        GameObject BGMbox = GameObject.Find("BGMbox");
        BGMControl BGMcontrol = BGMbox.GetComponent<BGMControl>();
        BGMcontrol.playBOSSBGM();
        //Destroy(PropCreator);
    }

    //暂停与继续
    public void BacktogameButton()
    {
        StopGame();
    }

    //退出游戏
    public void ExitGame()
    {
        Application.Quit();
    }

    //返回主菜单
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //重新开始
    public void StartAgain()
    {
        SceneManager.LoadScene("Gaming");
    }

    //成功界面显示
    public void Success()
    {
        success.SetActive(true);
    }

    public void Timeleft()
    {
        if (Time.timeSinceLevelLoad <= GameDuration)
        {
            time = (int)(GameDuration - Time.timeSinceLevelLoad);
        }
        else time = 0;
        timeText.text = "剩余时间: " + time.ToString();

    }

}
