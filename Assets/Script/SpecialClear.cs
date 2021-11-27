using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialClear : MonoBehaviour
{
    float timer = 0.2f;
    bool set = false;
    public GameObject toggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0 && !set)
        {
            set = true;
            toggle.SetActive(false);
            gameObject.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
        }
        else if(!set)
        {
            timer -= Time.deltaTime;
        }
    }
}
