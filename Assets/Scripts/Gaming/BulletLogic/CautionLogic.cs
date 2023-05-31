using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;
    void Start()
    {
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }
}
