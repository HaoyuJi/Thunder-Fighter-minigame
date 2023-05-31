using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    float dx, dy;
    void Start()
    {
        dx = Random.Range(0, speed);
        dy = (float)System.Math.Sqrt((System.Math.Pow(speed, 2.0f) - System.Math.Pow(dx, 2.0f)));
        Invoke("SelfDestroy", 20);
    }

    // Update is called once per frame
    void Update()
    {
        RamdomMove();
    }
    private void RamdomMove()
    {
        
        if (this.transform.position.x >= 9.6 || this.transform.position.x <= -9.6)
            dx = -dx;
        if (this.transform.position.y >= 5.2 || this.transform.position.y <= -5.2)
            dy = -dy;
        this.transform.Translate(dx*Time.deltaTime, -dy*Time.deltaTime, 0, Space.World);
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
    
}
