using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selfdestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime=3;
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
        Destroy(this.gameObject);
    }
}
