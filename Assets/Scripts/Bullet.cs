using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    public float scaleSpeed = 0.5f; // —корость изменени€ размера
    public float minScale = 0.1f;   // ћинимальный размер, чтобы избежать отрицательных значений

    private bool isMousePressed = true;

    public float speed = 100f; // —корость полета пули
    public float lifetime = 2f;

    void Update()
    {
        ChangeSize();
    }

    public void ChangeSize()
    {

        //Touch touch = Input.GetTouch(0);
        if (Input.GetMouseButtonUp(0))
        {

            Move();
            isMousePressed = false;
        }

        if (isMousePressed)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
            transform.localScale = Vector3.Max(transform.localScale, new Vector3(minScale, minScale, minScale));
        }
        //touch.phase == TouchPhase.Ended || 


    }

    public void Move()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }
}
