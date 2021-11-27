using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBar : MonoBehaviour
{
    public List<KeyCode> keys;
    public int keyIndex = 0;
    public int numPress = 10;

    public bool decreasing;
    public float decreaseSpeed = 1;

    public bool canFail = false;
    bool nowFail = false;
    public float failBorder = 0.2f;

    public Slider bar;

    public bool complete = false;
    public bool failed = false;

    public GameObject obj;
    Vector3 start;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (obj != null)
        {
            start = obj.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys[keyIndex]))
        {
            keyIndex++;
            bar.value += bar.maxValue / numPress;
            if (keyIndex == keys.Count)
            {
                keyIndex = 0;
            }
        }
        if(bar.value == bar.maxValue)
        {
            complete = true;
        }
        if (decreasing == true && complete == false)
        {
            bar.value -= decreaseSpeed *Time.deltaTime;
        }
        if(canFail == true)
        {
            if(bar.value >= failBorder)
            {
                nowFail = true;
            }
        }
        if(nowFail == true && bar.value <= 0.1f)
        {
            failed = true;
        }

        if(obj != null)
        {
            obj.transform.position = new Vector3(start.x, start.y + (bar.value * speed), start.z);
        }
    }
}
