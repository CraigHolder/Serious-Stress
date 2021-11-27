using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    GameData data;

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = data.stressLevel;
    }
}
