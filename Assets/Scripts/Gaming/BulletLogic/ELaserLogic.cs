using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ELaserLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;
    bool changesignal=true;
    void Start()
    {
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x >= 1.2f || this.transform.localScale.x <= 0.8f)
            changesignal = !changesignal;
        if(changesignal == true)
            this.transform.localScale = this.transform.localScale+ new Vector3(0.01f, 0, 0);
        if (changesignal == false)
            this.transform.localScale = this.transform.localScale - new Vector3(0.01f, 0, 0);
    }
    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }
}
