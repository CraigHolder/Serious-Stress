using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lunch : MonoBehaviour
{
    public List<string> ingredients;
    public int randNum;
    public int randNum2;
    GameData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
        randNum = Random.Range(1, 5);
        GameObject.FindGameObjectWithTag("Goal").GetComponent<Drop>().requiredCount = randNum;

        for (int i = 0; i < randNum; i++)
        {
            randNum2 = Random.Range(0, 5);
            if (GameObject.FindGameObjectWithTag("Goal").GetComponent<Drop>().goodValues.Contains(ingredients[randNum2]))
            {
                i--;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Goal").GetComponent<Drop>().goodValues.Add(ingredients[randNum2]);
                GameObject.FindGameObjectWithTag("Goal").GetComponent<Drop>().badValues.Remove(ingredients[randNum2]);
                GameObject.FindGameObjectWithTag("Text").GetComponent<TMP_Text>().text += " " + ingredients[randNum2];
            }
             //.goodValues.Add(ingredients[randNum2]);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
