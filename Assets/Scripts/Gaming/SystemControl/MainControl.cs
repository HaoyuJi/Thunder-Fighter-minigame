using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Menu;

    [Tooltip("��ʱ��")]
    public float GameDuration;

    [Tooltip("�������ɵ�")]
    public GameObject EnemyCreator;

    [Tooltip("BOSS���ɵ�")]
    public GameObject BOSSCreator;

    [Tooltip("�������ɵ�")]
    public GameObject PropCreator;

    [Tooltip("ʣ��ʱ����ʾ")]
    public Text timeText;

    [Tooltip("�ɹ�������ʾ")]
    public GameObject success;

    [Tooltip("BGM������")]
    public AudioSource BGMplayer;

    [Tooltip("������ЧԤ����")]
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
        timeText.text = "ʣ��ʱ��: " + GameDuration;
        
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

    //��ͣ�����
    public void BacktogameButton()
    {
        StopGame();
    }

    //�˳���Ϸ
    public void ExitGame()
    {
        Application.Quit();
    }

    //�������˵�
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //���¿�ʼ
    public void StartAgain()
    {
        SceneManager.LoadScene("Gaming");
    }

    //�ɹ�������ʾ
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
        timeText.text = "ʣ��ʱ��: " + time.ToString();

    }

}
