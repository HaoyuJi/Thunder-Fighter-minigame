using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("得分")]
    public Text scoreText;

    [Tooltip("最终得分")]
    public Text TotalscoreText;
    int score=0;
    int Totalscore = 100000;
    void Start()
    {
        scoreText.text = ": " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(TotalscoreText.gameObject.activeInHierarchy==true&& Totalscore< score)
        {
            Totalscore = Totalscore + 100;
            TotalscoreText.text="最终得分："+ Totalscore.ToString();
        }
    }
    public void addscore(int add)
    {
        score = score + add;
        scoreText.text = ": " + score.ToString();
    }

}
