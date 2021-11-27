using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakfast : MonoBehaviour
{

    public int randNum;
    GameData data;
    GameObject cereal;
    public float randX;
    public float randY;
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        cereal = Resources.Load<GameObject>("Cereal");
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
        box = gameObject.GetComponent<BoxCollider2D>();
        randNum = Random.Range(25, 50);

        for (int i = 1; i <= randNum; i++)
        {
            randX = Random.Range(box.bounds.min.x, box.bounds.max.x);
            randY = Random.Range(box.bounds.min.y, box.bounds.max.y);
            Instantiate(cereal, new Vector3(randX, randY, -8), Quaternion.identity);

        }









    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
