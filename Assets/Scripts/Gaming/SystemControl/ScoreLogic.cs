using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("�÷�")]
    public Text scoreText;

    [Tooltip("���յ÷�")]
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
            TotalscoreText.text="���յ÷֣�"+ Totalscore.ToString();
        }
    }
    public void addscore(int add)
    {
        score = score + add;
        scoreText.text = ": " + score.ToString();
    }

}
