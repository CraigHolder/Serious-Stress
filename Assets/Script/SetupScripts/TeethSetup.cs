using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethSetup : MonoBehaviour
{
    public GameObject bit;
    GameObject brush;
    public int randCrumb;
    public float randX;
    public float randY;
    GameData data;
    BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        bit = Resources.Load<GameObject>("FoodCrumb");
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
        box = gameObject.GetComponent<BoxCollider2D>();
        brush = GameObject.FindGameObjectWithTag("Brush");

        randCrumb = Random.Range(8, 12);
        if(data.stressLevel / 10 >=1)
        {
            randCrumb += ((int)data.stressLevel / 10);
        }
        brush.GetComponentInChildren<Drop>().requiredCount = randCrumb;


        for (int i = 1; i <= randCrumb; i++)
        {
            randX = Random.Range(box.bounds.min.x, box.bounds.max.x);
            randY = Random.Range(box.bounds.min.y, box.bounds.max.y);
            Instantiate(bit, new Vector3(randX, randY,0), Quaternion.identity);
        }
    }

}
