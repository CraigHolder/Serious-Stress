using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeNavi : MonoBehaviour
{
    public float speed;
    Vector2 move;
    Rigidbody2D rigi;

    Camera cam;

    GameData data;


    // Start is called before the first frame update
    void Start()
    {
        rigi = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("NaviCam").GetComponent<Camera>();
        cam.depth = 1;
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {

            move.y = 1;
        }
        else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            move.y = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move.y = -1;
        }
        else if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            move.y = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x = -1;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            move.x = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x = 1;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            move.x = 0;
        }

        rigi.MovePosition(new Vector2(transform.position.x + (move.x * speed * Time.deltaTime), transform.position.y + (move.y * speed * Time.deltaTime)));
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z) ;
        //transform.position = new Vector3(transform.position.x + (xSpeed * speed * Time.deltaTime), transform.position.y + (ySpeed * speed * Time.deltaTime), transform.position.z);
    }
}
