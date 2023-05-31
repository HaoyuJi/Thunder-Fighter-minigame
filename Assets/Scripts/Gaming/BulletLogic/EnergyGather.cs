using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGather : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;
    public float gatherspeed = 0.8f;
    public float rotatespeed = 1;
    void Start()
    {
        this.transform.localScale = Vector3.zero;
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, rotatespeed);
        if (this.transform.localScale.x< gatherspeed*1.2)
            this.transform.localScale = this.transform.localScale + new Vector3(1, 1, 1)* gatherspeed*Time.deltaTime;
    }

    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }
}
