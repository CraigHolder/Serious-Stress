using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : MonoBehaviour
{
    public int randNum;
    GameData data;
    GameObject whiteShirt;
    GameObject redShirt;

    

    // Start is called before the first frame update
    void Start()
    {
        redShirt = Resources.Load<GameObject>("RedShirt");
        whiteShirt = Resources.Load<GameObject>("WhiteShirt");
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
        randNum = Random.Range(4, 11);

        GameObject.FindGameObjectWithTag("Goal").GetComponent<Drop>().requiredCount = randNum;
        int redShirtNum =0;
        if ((data.stressLevel / 20f) >= 1)
        {
            redShirtNum = (int)(data.stressLevel / 20f);
        }

        for (int i = 1; i <= randNum; i++)
        {
            Instantiate(whiteShirt, new Vector3(transform.position.x, transform.position.x, -8 + Random.Range(-1f, 1f)), Quaternion.identity);
        }
        for (int i = 1; i <= redShirtNum; i++)
        {
            Instantiate(redShirt, new Vector3(transform.position.x, transform.position.x, -8 + Random.Range(-1f, 1f)), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
