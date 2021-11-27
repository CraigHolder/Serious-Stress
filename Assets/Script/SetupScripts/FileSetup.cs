using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSetup : MonoBehaviour
{
    public GameObject[] Files;

    public int randNum;
    public int randColour;
    public float randX;
    public float randY;
    GameData data;
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        Files = new GameObject[5];
        Files[0] = Resources.Load<GameObject>("RedFile");
        Files[1] = Resources.Load<GameObject>("BlueFile");
        Files[2] = Resources.Load<GameObject>("GreenFile");
        Files[3] = Resources.Load<GameObject>("YellowFile");
        Files[4] = Resources.Load<GameObject>("PurpleFile");

        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
        box = gameObject.GetComponent<BoxCollider2D>();

        
        randNum = Random.Range(12, 18);
        //randColour = 4;

        if (data.stressLevel / 10 >= 1)
        {
            randNum += ((int)data.stressLevel / 10);
        }


        for (int i = 1; i <= randNum; i++)
        {
            randColour = Random.Range(0, 5);
            randX = Random.Range(box.bounds.min.x, box.bounds.max.x);
            randY = Random.Range(box.bounds.min.y, box.bounds.max.y);
            switch(randColour)
            {
                case 0:
                    Instantiate(Files[0], new Vector3(randX, randY, -8), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Files[1], new Vector3(randX, randY, -8), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Files[2], new Vector3(randX, randY, -8), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Files[3], new Vector3(randX, randY, -8), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Files[4], new Vector3(randX, randY, -8), Quaternion.identity);
                    break;
            }
            //Instantiate(bit, new Vector3(randX, randY, 0), Quaternion.identity);
        }
    }
}
