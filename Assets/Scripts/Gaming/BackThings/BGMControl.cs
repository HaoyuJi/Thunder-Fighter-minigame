using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControl : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("音乐文件")]
    public AudioClip[] BGMbox;

    [Tooltip("音乐文件")]
    AudioSource BGMplayer;
    void Start()
    {
        BGMplayer = this.GetComponent<AudioSource>();
        playEnemy1BGM();
        Invoke("playEnemy2BGM", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playEnemy1BGM()
    {
        BGMplayer.clip = BGMbox[0];
        BGMplayer.Play();
    }

    public void playEnemy2BGM()
    {
        BGMplayer.clip = BGMbox[1];
        BGMplayer.Play();
    }
    public void playBOSSBGM()
    {
        BGMplayer.clip = BGMbox[2];
        BGMplayer.Play();
    }

    public void playSuccessBGM()
    {
        BGMplayer.clip = BGMbox[3];
        BGMplayer.Play();
    }

    public void playFailBGM()
    {
        BGMplayer.clip = BGMbox[4];
        BGMplayer.Play();
    }

}
