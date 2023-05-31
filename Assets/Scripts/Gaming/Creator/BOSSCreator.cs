using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("BOSS库")]
    public GameObject BOSSPrefab;

    [Tooltip("警告字样")]
    public GameObject Warning;

    [Tooltip("BOSS即将出现字样")]
    public GameObject BOSSemerge;
    Image bossfill;

    void Start()
    {
        Warning.SetActive(true);
        BOSSemerge.SetActive(true);
        bossfill = BOSSemerge.GetComponent<Image>();
        Invoke("BOSScreator", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(BOSSemerge.activeInHierarchy==true && bossfill.fillAmount <= 1)
            bossfill.fillAmount= bossfill.fillAmount+0.02f;
    }

    private void BOSScreator()
    {
        Warning.SetActive(false);
        BOSSemerge.SetActive(false);
        GameObject node = Instantiate(BOSSPrefab, this.transform);
        node.transform.position = this.transform.position;
    }
}
