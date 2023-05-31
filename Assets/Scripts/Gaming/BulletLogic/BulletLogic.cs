using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float MaxDistance;
    void Start()
    {
        float lifetime = System.Math.Abs(MaxDistance / speed);
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);
    }
    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }
}
