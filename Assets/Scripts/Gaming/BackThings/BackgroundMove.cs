using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;
    public float size = 20.48f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
        if (this.transform.position.y <= -size)
        {
            this.transform.position = new Vector3(this.transform.position.x, size, this.transform.position.z);
        }

    }
}
