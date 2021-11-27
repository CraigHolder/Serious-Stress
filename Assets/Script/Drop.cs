using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public List<string> goodValues;
    public List<string> badValues;

    public int acceptedCount = 0;
    public int requiredCount = 2;
    public bool failed = false;
    public bool complete = false;

    GameData data;
    // Start is called before the first frame update
    void Start()
    {

        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        if(acceptedCount == requiredCount)
        {
            complete = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Drag" || other.gameObject.tag == "Goal")
        {
            if (other.gameObject.GetComponent<Drag>() == null)
            {
                return;
            }
            Drag dragComp = other.gameObject.GetComponent<Drag>();
            if(dragComp.Dragging == true)
            {
                return;
            }
            foreach(string s in goodValues)
            {
                if (dragComp.value == s)
                {
                    acceptedCount++;
                    Destroy(other.gameObject);
                    return;
                }
            }
            foreach (string s in badValues)
            {
                if (dragComp.value == s)
                {
                    failed = true;
                    Destroy(other.gameObject);
                    return;
                }
            }
        }
    }
}
