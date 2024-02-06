using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    //private float scaleSpeed; // —корость изменени€ размера
    //public float minScale = 0.1f;   // ћинимальный размер, чтобы избежать отрицательных значений

    //private bool isMousePressed = false;
    // Start is called before the first frame update

    float scaleSpeedPath = 0.1f;
    bool isMousePressedPath = false;
    void Start()
    {
        //scaleSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressedPath = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressedPath = false;
        }

        if (isMousePressedPath)
        {
            transform.localScale -= new Vector3(scaleSpeedPath, 0, 0) * Time.deltaTime;
        }
    }


    /*
    public void ChangeSize()
    {

        //Touch touch = Input.GetTouch(0);
        //if (touch.phase == TouchPhase.Began || )
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }

        if (isMousePressed)
        {

            transform.localScale -= new Vector3(scaleSpeed, 0, 0) * Time.deltaTime;

            transform.localScale = Vector3.Max(transform.localScale, new Vector3(minScale, minScale, minScale));
        }
        //touch.phase == TouchPhase.Ended || 


    }*/
}
