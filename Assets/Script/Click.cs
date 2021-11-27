using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public bool destroy = true;
    public Vector3 movePoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(destroy)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = movePoint;
        }
    }
}
