using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private float scaleSpeed; // Скорость изменения размера
    public float minScale = 0.1f;   // Минимальный размер, чтобы избежать отрицательных значений

    private bool isMousePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        scaleSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSize();
    }

    public void ChangeSize()
    {

        //Touch touch = Input.GetTouch(0);
        Debug.Log("Нажатие на экран: ");
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


    }
}
