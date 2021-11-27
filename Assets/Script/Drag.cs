using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public string value;
    public bool Dragging;
    public bool cantDrag = false;

    Plane plane;
    Vector3 offset;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if(cantDrag)
        {
            return;
        }
        plane = new Plane(mainCamera.transform.forward, transform.position);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float dist;

        plane.Raycast(ray, out dist);
        offset = transform.position - ray.GetPoint(dist);
    }

    void OnMouseDrag()
    {
        if (cantDrag)
        {
            return;
        }
        Dragging = true;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        float dist;

        plane.Raycast(ray, out dist);
        transform.position = ray.GetPoint(dist) + offset;

    }

    void OnMouseUp()
    {
        if (cantDrag)
        {
            return;
        }
        Dragging = false;
    }




    /*Archive
    void Update()
    {
        if (cantDrag)
        {
            return;
        }
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                Dragging = true;
                offset = transform.position - (Vector3)mousePos;
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Dragging = false;
        }

        if (Dragging)
        {
            transform.position = mousePos + (Vector2)offset;
        }
        //{
        //    if (cantDrag)
        //    {
        //        return;
        //    }
        //    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //    float dist;

        //    plane.Raycast(ray, out dist);
        //    transform.position = ray.GetPoint(dist) + offset;
        //}
        //else
        //{
        //    Dragging = false;
        //}
    }

    public void Click()
    {
        if (cantDrag)
        {
            return;
        }
        Dragging = true;
        plane = new Plane(mainCamera.transform.forward, transform.position);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        float dist;

        plane.Raycast(ray, out dist);
        offset = transform.position - ray.GetPoint(dist);
    }*/
}

